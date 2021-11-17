using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Animator animator;
        [SerializeField] private LayerMask notMoveLayerMask;
        [SerializeField] private LayerMask tiggerLayerMask;

        private Vector2 movement;
        private bool isMove;

        [Header("Read Only")]
        [SerializeField]
        private float moveTime;
        private float startTime;

        private Vector3 targetPosition;

        private Vector2 towards;

        public event UnityAction MoveEnd;

        public bool Stop { get; set; }

        static PlayerController()
        {
            GlobalInput.PlayerAction.Menu = () => { UIManager.Get<MenuView>(); };

        }


        private void Start()
        {
            GlobalInput.DefaultAction.Move = (value) => movement = value;
            GlobalInput.PlayerAction.Move = GlobalInput.DefaultAction.Move;
            GlobalInput.PlayerAction.Confirm = ConfirmCallback;

            GlobalInput.SetFirst(GlobalInput.PlayerAction);
        }

        void Update()
        {
            
            if (isMove)
            {
                Moving();
            }
            else
            {
                if (!Stop)
                {
                    CheckMove();
                }
            }
        }

        private void CheckMove()
        {
            if (movement.x != 0)
            {
                towards.x = movement.x;
                towards.y = 0;
                StartMove(new Vector3(movement.x, 0, 0));
            }
            else if (movement.y != 0)
            {
                towards.x = 0;
                towards.y = movement.y;
                StartMove(new Vector3(0, movement.y, 0));
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        private void StartMove(Vector3 direction)
        {
            var startPosition = transform.position;
            var targetPosition = startPosition + direction;
            var checkPoint = targetPosition + new Vector3(0, 0.5f, 0);

            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
            animator.SetBool("Walk", true);

            //检测障碍
            if (CanMoveTo(checkPoint))
            {
                startTime = Time.time;
                moveTime = 0;

                isMove = true;
                this.targetPosition = targetPosition;

                //禁止输入
                GlobalInput.RemoveFirst(GlobalInput.PlayerAction);
            }
        }

        private bool CanMoveTo(Vector2 point)
        {
            var collider = Physics2D.OverlapCircle(point, 0.4f, notMoveLayerMask);
            if (collider == null)
            {
                return true;
            }
            else
            {
                var obstacle = collider.GetComponent<Obstacle>();
                if (obstacle == null)
                {
                    return true;
                }
                else
                {
                    return obstacle.CanMove();
                }
            }
        }

        public void Moving()
        {
            animator.speed = moveSpeed;

            moveTime = Time.time - startTime;
            var position = transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            float distance = Vector3.Distance(position, targetPosition);
            if (distance <= 0.0001f)
            {
                isMove = false;

                animator.SetBool("Walk", false);

                //恢复输入
                GlobalInput.SetFirst(GlobalInput.PlayerAction);

                MoveEnd?.Invoke();
            }
        }

        public void StopMove()
        {
            isMove = false;
            targetPosition = Vector3.zero;
            animator.SetBool("Walk", false);
        }




        public void ConfirmCallback()
        {
            if (isMove) return;

            Vector2 forwardPoint = towards + (Vector2)transform.position + new Vector2(0, 0.5f);

            var collider2D = Physics2D.OverlapCircle(forwardPoint, 0.4f, tiggerLayerMask);
            if (collider2D != null)
            {
                var triggerable = collider2D.GetComponent<ITriggerable>();
                if (triggerable != null)
                {
                    triggerable.PlayerTriggerable(this);
                }
            }
        }



#if UNITY_EDITOR
        private Vector2 tempMovement;
        private void OnDrawGizmos()
        {
            if (movement != Vector2.zero)
            {
                tempMovement = movement;
            }

            Vector3 position = transform.position + new Vector3(tempMovement.x, tempMovement.y + 0.5f, 0);
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