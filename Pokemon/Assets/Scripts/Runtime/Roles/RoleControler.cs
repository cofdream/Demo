using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class RoleControler : MonoBehaviour
    {
        [SerializeField] Animator animator;

        [SerializeField] StateType stateType;
        private bool isStopMovment;//是否停止移动
        private Vector2 moveInputValue;
        public StateType CurStateType => stateType;

        //move
        private Vector3 targetPoint;//移动状态的目标点
        private Vector3 forwardPoint;//前方点
        private Vector2 forward;//前方
        [SerializeField] float speed;
        [SerializeField] LayerMask obstacleLayer;
        public Vector2 ForwardPoint => forwardPoint;
        public LayerMask ObstacleLayer => obstacleLayer;
        public UnityAction MoveEndEvent;

        // turn to
        private float turnToTime = 0.4f;
        private float curTurnToTime;


        public enum StateType
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
            forwardPoint = transform.position + new Vector3(forward.x, forward.y, 0);
        }

        void Update()
        {
            switch (stateType)
            {
                case StateType.Idle:
                    IdleState();
                    break;
                case StateType.Move:
                    UpdateMoveState();
                    break;
                case StateType.TurnTo:
                    UpdateTurnToState();
                    break;
                default:
                    break;
            }
        }

        public void SetInutValue(Vector2 value)
        {
            if (value != Vector2.zero)
            {
                if (value.x != 0)
                {
                    value.y = 0;
                }

                moveInputValue = value;
                isStopMovment = false;
            }
        }
        public void StopMove()
        {
            isStopMovment = true;
        }

        public void SetForward(Vector2 forward)
        {
            this.forward = forward;
            forwardPoint = transform.position + new Vector3(this.forward.x, this.forward.y, 0);
            SetAniParameters(this.forward);
        }

        // 待机状态
        private void IdleState()
        {
            if (isStopMovment == false)
            {
                if (forward != moveInputValue)
                {
                    stateType = StateType.TurnTo;

                    forward = moveInputValue;
                    forwardPoint = transform.position + new Vector3(forward.x, forward.y, 0);
                    PlayeTurnToAni(forward);
                    curTurnToTime = 0;
                }
                else
                {
                    stateType = StateType.Move;

                    EnterMoveState();
                }
            }
        }


        // 移动状态
        private void EnterMoveState()
        {
            CheckObstackeAndSetTargetPoint();
            PlayMoveAni();
        }
        private void UpdateMoveState()
        {
            Vector3 value = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            if (Vector3.Distance(value, targetPoint) < 0.001f)
            {
                //移动结束
                transform.position = targetPoint;
                forwardPoint = targetPoint + new Vector3(forward.x, forward.y, 0);

                MoveEndEvent?.Invoke();

                //再移动
                if (isStopMovment)
                {
                    PlayIdleAni();
                    stateType = StateType.Idle;
                }
                else
                {
                    //转向
                    if (forward != moveInputValue)
                    {
                        forward = moveInputValue;
                        forwardPoint = transform.position + new Vector3(forward.x, forward.y, 0);

                        SetAniParameters(forward);
                    }

                    CheckObstackeAndSetTargetPoint();
                }
            }
            else
            {
                transform.position = value;
            }
        }
        private void CheckObstackeAndSetTargetPoint()
        {
            //检测前方障碍物
            var collider = Physics2D.OverlapCircle(forwardPoint, 0.4f, obstacleLayer);
            if ((object)collider == null)
            {
                //没有障碍，设前一格为置目标点
                targetPoint = forwardPoint;
            }
            else
            {
                targetPoint = transform.position;
            }
        }
        private void PlayMoveAni()
        {
            animator.SetBool("Walk", true);
        }
        private void PlayIdleAni()
        {
            animator.SetBool("Walk", false);
        }
        private void SetAniParameters(Vector2 value)
        {
            animator.SetFloat("X", value.x);
            animator.SetFloat("Y", value.y);
        }


        //旋转状态
        private void UpdateTurnToState()
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
    }
}