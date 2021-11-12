using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 movement;

        private float BaseSpeed = 1.5f;
        public float moveSpeed;
        public Animator animator;

        private bool isMove;

        private Vector3 targetPosition;

        public float moveTime;
        private float startTime;

        public event UnityAction MoveEnd;

        public bool Stop { get; set; }

        void Start()
        {

        }


        void Update()
        {
            if (isMove)
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
            if (movement != Vector3.zero)
            {
                StartMove(movement);
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
            if (CheckMove(checkPoint))
            {
                startTime = Time.time;
                moveTime = 0;

                CheckTrigger(checkPoint);

                isMove = true;
                this.targetPosition = targetPosition;
            }
        }
        public void StopMove()
        {
            isMove = false;
            targetPosition = Vector3.zero;
            animator.SetBool("Walk", false);
        }
        private void Move()
        {
            animator.speed = moveSpeed;

            moveTime = Time.time - startTime;
            var position = transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * BaseSpeed * moveSpeed);

            float distance = Vector3.Distance(position, targetPosition);
            if (distance <= 0.0001f)
            {
                isMove = false;
                animator.SetBool("Walk", false);
                MoveEnd?.Invoke();
            }
        }

        private bool CheckMove(Vector2 poit)
        {
            var collider2D = Physics2D.OverlapCircle(poit, 0.4f, LayerMask.GetMask("Obstacle"));

            return collider2D == null;
        }

        private void CheckTrigger(Vector2 poit)
        {
            var collider2D = Physics2D.OverlapCircle(poit, 0.4f, LayerMask.GetMask("Triggerable"));
            if (collider2D != null)
            {
                var triggerable = collider2D.GetComponent<ITriggerable>();
                if (triggerable != null)
                {
                    triggerable.Enter(this);
                }
            }
        }


        private void OnMove(UnityEngine.InputSystem.InputValue value)
        {
            var vector2 = value.Get<Vector2>();
            if (vector2.x != 0)
            {
                vector2.y = 0;
            }

            movement = vector2;
        }

        private void OnDrawGizmos()
        {
            float ho = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            if (ho != 0)
            {
                ver = 0;
            }
            else if (ver == 0)
            {
                return;
            }

            Vector3 position = transform.position + new Vector3(ho, ver + 0.5f, 0);
            if (CheckMove(position))
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawSphere(position, 0.4f);
        }
    }
}