using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Move With Root Motion")]
    public class MoveWithRootMotion : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.animator.transform.localPosition = Vector3.zero;
            states.rigidbody.drag = 0;

            Vector3 v = states.rigidbody.velocity;
            Vector3 targetV = states.animator.deltaPosition;

            targetV *= 60;
            targetV.y = v.y;

            states.rigidbody.velocity = targetV;
        }
    }
}
