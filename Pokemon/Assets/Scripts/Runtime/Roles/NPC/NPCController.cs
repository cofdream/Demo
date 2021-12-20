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
        public float sightDistance = 5f;
        public LayerMask PlayerLayer;

        StateType stateType;

        public float PatrolLength;

        private enum StateType
        {
            Patrol,
            Fight,
        }

        private void Start()
        {
            stateType = StateType.Patrol;

            transform.position = startPosition;
            roleControler.MoveEndEvent = MoveEnd;
            roleControler.SetInutValue(forward);
        }

        private void Update()
        {
            switch (stateType)
            {
                case StateType.Patrol:
                    PatrolState();
                    break;
                case StateType.Fight:
                    FifghtState();
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

        //巡视
        private void PatrolState()
        {
            var hit2Ds = Physics2D.RaycastAll(transform.position, forward, sightDistance, PlayerLayer.value);
            if (hit2Ds.Length == 1)
            {
                var player = hit2Ds[0].transform.GetComponent<PlayerController>();
                if (player != null)
                {
                    stateType = StateType.Fight;

                    Debug.Log("Fight");
                    //锁定玩家移动

                    //移动到玩家前面

                }
            }
            Debug.DrawRay(transform.position, forward * sightDistance, Color.red);
        }

        private void FifghtState()
        {
            //
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