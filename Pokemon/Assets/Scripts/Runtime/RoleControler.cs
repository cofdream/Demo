using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class RoleControler : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Animator animator;

        bool isStopMove;//是否停止移动
        bool isMovement;//是否在运动
        Vector2 forward;

        public Vector2 Forword => forward;

        private Vector2 movement;

        public bool grid = true;

        private void Awake()
        {
            forward = new Vector2(0, -1);
            isStopMove = true;
        }

        void Update()
        {
            // 模拟外部输入调用
            Vector2 value;
            value.x = Input.GetAxisRaw("Horizontal");
            value.y = Input.GetAxisRaw("Vertical");


            if (value == Vector2.zero)
            {
                StopMove();
            }
            else
            {
                SetMoveValue2(value);
            }
        }


        public void SetMoveValue2(Vector2 value)
        {
            //调整输入值 
            if (value.x != 0) value.y = 0;

            movement = value;

            if (isMovement == false)
            {
                StartCoroutine(OnMove());
            }
        }

        private IEnumerator OnMove()
        {
            isStopMove = false;
            isMovement = true;
        _move:

            //转向
            if (movement - forward != Vector2.zero)
            {
                forward = movement;

                PlayeTurnToAni();

                // old
                {
                    yield return new WaitForSeconds(0.33f);
                }

                if (isStopMove)
                {
                    isMovement = false;
                    PlayIdleAni();
                    yield break;
                }
                else
                    goto _move;
            }

            //移动
            bool canMoving = CheckGridCanMoving();
            if (canMoving)
            {
                //无障碍
                PlayMoveAni();

                Vector3 target = transform.position + new Vector3(forward.x, forward.y, 0);
                while (true)
                {
                    Vector3 value = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                    if (Vector3.Distance(value, target) < 0.001f)
                    {
                        transform.position = target;

                        if (isStopMove)
                        {
                            isMovement = false;
                            PlayIdleAni();
                            break;
                        }
                        else
                            goto _move;
                    }
                    else
                    {
                        transform.position = value;
                        yield return null;
                    }
                }
            }
            else
            {
                //有障碍 不可位移
                PlayMoveAni();
                while (true)
                {
                    if (isStopMove)
                    {
                        isMovement = false;
                        PlayIdleAni();
                        break;
                    }
                    else
                    {
                        Debug.Log("有障碍 不可位移");
                        yield return null;
                    }
                }
            }

        }


        public void StopMove()
        {
            if (isStopMove == false)
            {
                isStopMove = true;
                // stop move
            }
        }

        private void PlayeTurnToAni()
        {
            animator.SetBool("Walk", true);
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }

        private bool CheckGridCanMoving()
        {
            return grid;
        }
        private void PlayMoveAni()
        {
            animator.SetBool("Walk", true);
        }
        private void PlayIdleAni()
        {
            animator.SetBool("Walk", false);
        }
        // todo
        // 动画和移动不是很匹配。可以调整一下



        //private void CheckMove()
        //{
        //    if (Stop) return;


        //    // 
        //    // StartMove()
        //    // SetMove(vector2 value)
        //    // StopMove()


        //    //  移动
        //    //      转向
        //    //      位移





        //    if (movement.x != 0)
        //    {
        //        towards.x = movement.x;
        //        towards.y = 0;
        //        StartMove(new Vector3(movement.x, 0, 0));
        //    }
        //    else if (movement.y != 0)
        //    {
        //        towards.x = 0;
        //        towards.y = movement.y;
        //        StartMove(new Vector3(0, movement.y, 0));
        //    }
        //    else
        //    {
        //        animator.SetBool("Walk", false);
        //    }
        //}
        //private void StartMove(Vector3 direction)
        //{
        //    var startPosition = transform.position;
        //    var targetPosition = startPosition + direction;
        //    var checkPoint = targetPosition + new Vector3(0, 0.5f, 0);

        //    animator.SetFloat("X", direction.x);
        //    animator.SetFloat("Y", direction.y);
        //    animator.SetBool("Walk", true);

        //    //检测障碍
        //    if (CanMoveTo(checkPoint))
        //    {
        //        startTime = Time.time;
        //        moveTime = 0;

        //        isMove = true;
        //        this.targetPosition = targetPosition;

        //        //禁止输入
        //        GlobalInput.RemoveFirst(GlobalInput.PlayerAction);
        //    }
        //}

        //private bool CanMoveTo(Vector2 point)
        //{
        //    var collider = Physics2D.OverlapCircle(point, 0.4f, notMoveLayerMask);
        //    if (collider == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        var obstacle = collider.GetComponent<Obstacle>();
        //        if (obstacle == null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return obstacle.CanMove();
        //        }
        //    }
        //}

        //public void Moving()
        //{
        //    animator.speed = speed;

        //    moveTime = Time.time - startTime;
        //    var position = transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        //    float distance = Vector3.Distance(position, targetPosition);
        //    if (distance <= 0.0001f)
        //    {
        //        isMove = false;

        //        animator.SetBool("Walk", false);

        //        //恢复输入
        //        GlobalInput.SetFirst(GlobalInput.PlayerAction);

        //        MoveEnd?.Invoke();
        //    }
        //}



        //public void ConfirmCallback()
        //{
        //    if (isMove) return;

        //    Vector2 forwardPoint = towards + (Vector2)transform.position + new Vector2(0, 0.5f);

        //    var collider2D = Physics2D.OverlapCircle(forwardPoint, 0.4f, tiggerLayerMask);
        //    if (collider2D != null)
        //    {
        //        var triggerable = collider2D.GetComponent<ITriggerable>();
        //        if (triggerable != null)
        //        {

        //        }
        //    }
        //}



#if UNITY_EDITOR
        private Vector2 tempMovement;
        private void OnDrawGizmos()
        {
            if (forward != Vector2.zero)
            {
                tempMovement = forward;
            }

            Vector3 position = transform.position + new Vector3(tempMovement.x, tempMovement.y, 0);
            //if (Check(position))
            //{
            //    Gizmos.color = Color.green;
            //}
            //else
            //{
            //    Gizmos.color = Color.red;
            //}
            Gizmos.color = Color.green;

            Gizmos.DrawSphere(position, 0.4f);
        }
#endif
    }
}
