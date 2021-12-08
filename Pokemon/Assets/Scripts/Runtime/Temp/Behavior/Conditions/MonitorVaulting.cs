using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/Monitor Vaulting")]
    public class MonitorVaulting : Condition
    {
        public float origin_1_Offest = 1;
        public float rayForWardDis = 1;
        public float origin_2_Offest = 1;
        public float rayDownDis = 1.5f;
        public float vaulOffsetPostion = 2;

        public AnimationClip vaultWalkClip;
        public override bool CheckCondition(StateManager state)
        {
            bool result = false;

            Vector3 origin = state.mTransform.position;
            origin.y += origin_1_Offest;
            Vector3 direction = state.mTransform.forward;


            Debug.DrawRay(origin, direction * rayForWardDis);
            if (Physics.Raycast(origin, direction, out RaycastHit hit, rayForWardDis))
            {
                Vector3 origin2 = origin;
                origin2.y += origin_2_Offest;

                Vector3 firstHit = hit.point;
                firstHit.y -= origin_1_Offest;

                Debug.DrawRay(origin2, direction * rayForWardDis);
                if (Physics.Raycast(origin2, direction, out hit, rayForWardDis))
                {

                }
                else
                {
                    Vector3 origin3 = origin2 + (direction * rayForWardDis);

                    Debug.DrawRay(origin3, -Vector3.up * rayDownDis);
                    if (Physics.Raycast(origin3, -Vector3.up, out hit, rayDownDis))
                    {
                        result = true;
                        state.animator.SetBool(state.hashes.isInteracting, true);
                        state.animator.CrossFade(state.hashes.VaultWalk, 0.2f);
                        state.vaultData.animLength = vaultWalkClip.length;
                        state.vaultData.isInit = false;
                        state.isVaulting = true;

                        state.vaultData.startPosition = state.transform.position;

                        Vector3 endPosition = firstHit;
                        endPosition += direction.normalized * vaulOffsetPostion;

                        state.vaultData.endingPosition = endPosition;
                    }
                }
            }

            return result;
        }
    }
}
