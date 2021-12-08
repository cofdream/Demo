using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Anim_MovementForward")]
    public class Ani_MovementForward : StateActions
    {
        public StateActions[] stateActions;
        public override void Execute(StateManager states)
        {
            if (stateActions != null)
            {
                foreach (var stateAction in stateActions)
                {
                    stateAction.Execute(states);
                }
            }

            states.animator.SetFloat(states.hashes.vertical, states.movementVariables.moveAmount, 0.2f, states.delta);
        }
    }

}