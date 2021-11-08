using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class NPCController : MonoBehaviour
    {
        public float moveSpeed = 1.5f;
        public Animator animator;

        private bool isMove;

        private Vector3 startPosition;
        private Vector3 targetPosition;

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
                WaitInput();
            }
        }

        private void WaitInput()
        {
            float ho = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            if (ho != 0)
            {
                StartMove(new Vector3(ho, 0, 0));

            }
            else if (ver != 0)
            {

                StartMove(new Vector3(0, ver, 0));
            }
        }
        private void StartMove(Vector3 position)
        {
            isMove = true;
            startPosition = transform.position;
            targetPosition = startPosition + position;

            animator.SetFloat("X", position.x);
            animator.SetFloat("Y", position.y);
            animator.SetBool("Walk", true);
        }
        private void Move()
        {
            Vector3 position = transform.position;

            transform.position = Vector3.MoveTowards(position, targetPosition, Time.deltaTime * moveSpeed);

            float distance = Vector3.Distance(position, targetPosition);
            if (distance <= 0.01f)
            {
                isMove = false;
                transform.position = targetPosition;

                animator.SetBool("Walk", false);
            }
        }
    }
}
