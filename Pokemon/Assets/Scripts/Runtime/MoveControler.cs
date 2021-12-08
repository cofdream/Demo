using Cofdream.ToolKit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class MoveControler : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Animator animator;

        [ReadOnly, SerializeField] bool isStopMove;//是否停止移动
        [ReadOnly, SerializeField] bool isMovement;//是否在运动
        [ReadOnly, SerializeField] Vector2 forward;
        [ReadOnly, SerializeField] Vector2 movement;
        [ReadOnly, SerializeField] Vector3 target;

        public Func<bool> CheckForwardGrid;
        public UnityAction MoveOnceEnd;

        public Vector2 Forward => forward;
        public Vector3 MoveToPosition => target;

        private void Awake()
        {
            forward = new Vector2(0, -1);
            isStopMove = true;
        }



        public void SetMoveValue(Vector2 value)
        {
            //调整输入值 
            if (value.x != 0) value.y = 0;

            movement = value;

            isStopMove = false;

            if (isMovement == false)
            {
                StartCoroutine(OnMove());
            }
        }

        private IEnumerator OnMove()
        {
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
            target = transform.position + new Vector3(forward.x, forward.y, 0);
            bool canMoving = CheckGridCanMoving();
            if (canMoving)
            {
                //无障碍
                PlayMoveAni();

                while (true)
                {
                    Vector3 value = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                    if (Vector3.Distance(value, target) < 0.001f)
                    {
                        transform.position = target;

                        if (IsContinueMove())
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
                        //Debug.Log("有障碍 不可位移");
                        yield return null;
                    }
                }
            }

        }


        private bool CheckGridCanMoving()
        {
            if (CheckForwardGrid != null)
            {
                return CheckForwardGrid.Invoke();
            }
            return true;
        }
        private bool IsContinueMove()
        {
            MoveOnceEnd?.Invoke();
            return isStopMove;
        }
        public void StopMove()
        {
            if (isStopMove == false)
            {
                isStopMove = true;
                // stop move
            }
            //Debug.Log("Stop");
        }

        private void PlayeTurnToAni()
        {
            animator.SetBool("Walk", true);
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
        private void PlayMoveAni()
        {
            animator.SetBool("Walk", true);
        }
        private void PlayIdleAni()
        {
            animator.SetBool("Walk", false);
        }

        //       private Vector2 movementValue;
        //       private bool Quit;

        //       public IdleState idleState;
        //       public RotationState rotationState;

        //       public State state;

        //       private void Start()
        //       {
        //           state = idleState;
        //       }

        //       private void Update()
        //       {
        //           var newState = state.Tick();
        //           if (newState != null)
        //           {
        //               state.Exit();
        //               state = newState;
        //               state.Enter(this);
        //           }
        //       }


        //       [System.Serializable]
        //       public class State
        //       {
        //           public State[] states;
        //           MoveControler moveControler;
        //           public virtual void Enter(MoveControler moveControler) { this.moveControler = moveControler; }
        //           public virtual State Tick() { return null; }

        //           public virtual void Exit() { }

        //       }

        //       [System.Serializable]
        //       public class IdleState : State
        //       {
        //           if (true)
        //{

        //}
        //       }

        //       [System.Serializable]
        //       public class RotationState : State
        //       {

        //       }










        // todo
        // 动画和移动不是很匹配。可以调整一下




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



        //bool isMoving2;
        //Vector2 mo;
        //public void SetMovement(Vector2 value)
        //{
        //    mo = value;

        //}


        //private void Update()
        //{

        //    if (isMoving2)
        //    {
        //        Vector3 value = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //        if (Vector3.Distance(value, target) < 0.001f)
        //        {
        //            transform.position = target;
        //            isMoving2 = false;
        //        }
        //        else
        //        {
        //            transform.position = value;
        //        }
        //    }
        //}


        //private IEnumerator Movment()
        //{
        //    /*
        //    移动 走格子
        //    位移->开携程（移动 -> 移动结束以后 输入为 zero/bool stop 退出移动
        //    旋转->开携程（等待旋转动画结束
        //    */
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