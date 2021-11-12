using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject mainGO;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Animator animator;

        private Vector2 movement;
        private float baseSpeed = 1.5f;//
        private bool isMoving;

        public float moveTime;
        private float startTime;

        private Vector3 targetPosition;

        private Vector2 towards;

        public event UnityAction MoveEnd;

        public bool Stop { get; set; }
        public Vector2 ForwardPoint => towards + (Vector2)mainGO.transform.position + new Vector2(0, 0.5f);
        public bool IsMoving => isMoving;

        void Update()
        {
            if (isMoving)
            {
                Move();
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
            var startPosition = mainGO.transform.position;
            var targetPosition = startPosition + direction;
            var checkPoint = targetPosition + new Vector3(0, 0.5f, 0);

            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
            animator.SetBool("Walk", true);
            if (CheckMove(checkPoint))
            {
                startTime = Time.time;
                moveTime = 0;

                isMoving = true;
                this.targetPosition = targetPosition;
            }
        }
        public void StopMove()
        {
            isMoving = false;
            targetPosition = Vector3.zero;
            animator.SetBool("Walk", false);
        }
        private void Move()
        {
            animator.speed = moveSpeed;

            moveTime = Time.time - startTime;
            var position = mainGO.transform.position = Vector3.MoveTowards(mainGO.transform.position, targetPosition, Time.deltaTime * baseSpeed * moveSpeed);

            float distance = Vector3.Distance(position, targetPosition);
            if (distance <= 0.0001f)
            {
                isMoving = false;
                animator.SetBool("Walk", false);
                MoveEnd?.Invoke();
            }
        }

        private bool CheckMove(Vector2 poit)
        {
            var collider2D = Physics2D.OverlapCircle(poit, 0.4f, LayerMask.GetMask("Triggerable"));

            if (collider2D != null)
            {
                var triggerable = collider2D.GetComponent<ITriggerable>();
                if (triggerable != null)
                {
                    return triggerable.PlayerTriggerable(this);
                }
                return false;
            }

            return true;
        }


        private void OnMove(UnityEngine.InputSystem.InputValue value)
        {
            var vector2 = value.Get<Vector2>();
            Debug.Log(vector2);
            movement = vector2;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (movement == Vector2.zero)
            {
                return;
            }

            Vector3 position = mainGO.transform.position + new Vector3(movement.x, movement.y + 0.5f, 0);
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