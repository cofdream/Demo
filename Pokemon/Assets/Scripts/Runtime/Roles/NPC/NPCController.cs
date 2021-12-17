using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] RoleControler roleControler;

        public Vector2 startPosition;
        public Vector2 targetPosition;

        public Vector2 forward;

        StateType stateType;

        public float PatrolLength;

        private enum StateType
        {
            Idle,
            Patrol,
            Fight,
        }

        private void Start()
        {
            stateType = StateType.Idle;

            transform.position = startPosition;
            roleControler.MoveEndEvent = MoveEnd;
            roleControler.SetInutValue(forward);
        }

        private void Update()
        {
            switch (stateType)
            {
                case StateType.Idle:
                    IdleState();
                    break;
                case StateType.Patrol:
                    break;
                case StateType.Fight:
                    break;
                default:
                    break;
            }
        }

        private void MoveEnd()
        {
            if (Vector3.Distance(transform.position, new Vector3(targetPosition.x, targetPosition.y, 0)) < 0.001f)
            {
                roleControler.StopMove();
                StartCoroutine(Loop());
            }
        }

        private IEnumerator Loop()
        {
            yield return new WaitForSeconds(2f);

            var temp = startPosition;
            startPosition = targetPosition;
            targetPosition = temp;

            forward = -forward;

            roleControler.SetInutValue(forward);
        }

        //待机
        private void IdleState()
        {
            //检测是否可以移动
            stateType = StateType.Idle;
        }


        //巡视
        private void PatrolState()
        {
            
        }



#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if ((object)roleControler == null)
            {
                return;
            }

            Vector3 position = roleControler.ForwardPoint;
            var collider = Physics2D.OverlapCircle(position, 0.4f, roleControler.ObstacleLayer);
            if (collider == null)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawWireCube(position, Vector3.one * 0.4f);
        }
#endif
    }
}