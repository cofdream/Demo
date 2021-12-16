using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class RoleControler : MonoBehaviour
    {
        public bool grid = true;


        [SerializeField] Animator animator;

        [SerializeField] StateType stateType;
        private bool isStopMovment;//是否停止移动
        private Vector2 moveInputValue;

        //move
        private Vector3 targetPos;
        private Vector2 forward;
        [SerializeField] float speed;

        // turn to
        private float turnToTime = 0.4f;
        private float curTurnToTime;

        private enum StateType
        {
            Idle,
            Move,
            TurnTo,
        }

        private void Awake()
        {
            isStopMovment = true;

            stateType = StateType.Idle;
            forward = new Vector2(0, -1);
        }

        void Update()
        {
            // 模拟外部输入调用
            Vector2 value;
            value.x = Input.GetAxisRaw("Horizontal");
            value.y = Input.GetAxisRaw("Vertical");


            SetInutValue(value);

            switch (stateType)
            {
                case StateType.Idle:
                    IdleState();
                    break;
                case StateType.Move:
                    MoveState();
                    break;
                case StateType.TurnTo:
                    TurnToState();
                    break;
                default:
                    break;
            }
        }

        private void SetInutValue(Vector2 value)
        {
            if (value == Vector2.zero)
            {
                moveInputValue = Vector2.zero;
                isStopMovment = true;
            }
            else
            {
                if (value.x != 0)
                {
                    value.y = 0;
                }
                moveInputValue = value;
                isStopMovment = false;
            }

        }


        private void IdleState()
        {
            if (isStopMovment == false)
            {
                if (forward != moveInputValue)
                {
                    forward = moveInputValue;
                    PlayeTurnToAni(forward);
                    curTurnToTime = 0;
                    stateType = StateType.TurnTo;
                }
                else
                {
                    forward = moveInputValue;
                    targetPos = transform.position + new Vector3(forward.x, forward.y, 0);
                    PlayMoveAni();
                    stateType = StateType.Move;
                }
            }
        }

        private void MoveState()
        {
            Vector3 value = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector3.Distance(value, targetPos) < 0.001f)
            {
                transform.position = targetPos;
                if (isStopMovment)
                {
                    PlayIdleAni();
                    stateType = StateType.Idle;
                }
                else
                {
                    if (forward != moveInputValue)
                    {
                        forward = moveInputValue;
                        PlayeTurnToAni(forward);
                    }
                    targetPos = transform.position + new Vector3(forward.x, forward.y, 0);
                }
            }
            else
            {
                transform.position = value;
            }
        }

        private void TurnToState()
        {
            curTurnToTime += Time.deltaTime;
            if (curTurnToTime >= turnToTime)
            {
                PlayIdleAni();
                stateType = StateType.Idle;
            }
        }

        private void PlayeTurnToAni(Vector2 value)
        {
            animator.SetBool("Walk", true);
            animator.SetFloat("X", value.x);
            animator.SetFloat("Y", value.y);
        }

        private void PlayMoveAni()
        {
            animator.SetBool("Walk", true);
        }
        private void PlayIdleAni()
        {
            animator.SetBool("Walk", false);
        }


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

            Gizmos.DrawWireCube(position, Vector3.one * 0.4f);
        }
#endif
    }
}