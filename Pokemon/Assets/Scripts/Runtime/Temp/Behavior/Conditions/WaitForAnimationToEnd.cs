using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/Wait for animation to end")]
    public class WaitForAnimationToEnd : Condition
    {
        public string targetBool = "isInteracting";

        public override bool CheckCondition(StateManager state)
        {
            bool retVal = !state.animator.GetBool(targetBool);
            return retVal;
        }
    }

}