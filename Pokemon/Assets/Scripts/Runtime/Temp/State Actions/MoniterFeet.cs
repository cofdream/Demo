using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/MoniterFeet Position")]
    public class MoniterFeet : StateActions
    {

        public override void Execute(StateManager states)
        {
            Vector3 lf_relative = states.mTransform.InverseTransformPoint(states.animatorData.leftFoot.position);
            Vector3 rf_relative = states.mTransform.InverseTransformPoint(states.animatorData.rightFoot.position);

            bool leftForward = false;
            if (lf_relative.z > rf_relative.z)
            {
                leftForward = true;
            }
            states.animator.SetBool(states.hashes.leftFootForward, leftForward);

        }
    }

}