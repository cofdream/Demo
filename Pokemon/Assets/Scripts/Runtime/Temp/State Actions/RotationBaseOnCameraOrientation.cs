using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Rotate Based On Cam Orien")]
    public class RotationBaseOnCameraOrientation : StateActions
    {
        public TransformVariable cameraTransform;
        public float speed = 8;
        public override void Execute(StateManager states)
        {
            if (cameraTransform.value == null) return;

            float h = states.movementVariables.horizontal;
            float v = states.movementVariables.vertical;

            Vector3 targetDirection = cameraTransform.value.forward * v + cameraTransform.value.right * h;
            targetDirection.Normalize();
            targetDirection.y = 0;

            if (targetDirection == Vector3.zero)
            {
                targetDirection = states.mTransform.forward;
            }

            Quaternion tragetRotation = Quaternion.LookRotation(targetDirection);
            states.mTransform.rotation = Quaternion.Slerp(states.mTransform.rotation, tragetRotation, states.delta * states.movementVariables.moveAmount * speed);
        }
    }
}