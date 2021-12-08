using System.Collections;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Vault Movement")]
    public class VaultMovement : StateActions
    {
        public override void Execute(StateManager states)
        {
            VaultData vaultData = states.vaultData;

            if (!vaultData.isInit)
            {
                vaultData.vaultT = 0;
                vaultData.isInit = true;

                Vector3 dir = vaultData.endingPosition - vaultData.startPosition;
                dir.y = 0;
                Quaternion rot = Quaternion.LookRotation(dir);
                states.mTransform.rotation = rot;
            }

            float actuakSpeed = (states.delta * vaultData.vaultSpeed) / vaultData.animLength;

            vaultData.vaultT += actuakSpeed;

            if (vaultData.vaultT > 1)
            {
                vaultData.isInit = false;
                states.isVaulting = false;
            }

            Vector3 targetPosition = Vector3.Lerp(vaultData.startPosition, vaultData.endingPosition, vaultData.vaultT);
            states.mTransform.position = targetPosition;

        }
    }
}