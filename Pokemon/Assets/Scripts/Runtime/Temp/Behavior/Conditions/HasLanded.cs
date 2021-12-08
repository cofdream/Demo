using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/HasLanded")]
    public class HasLanded : Condition
    {
        public float hardLandThreshold = 1.5f;
        public float maxLandThreshold = 4;
        public override bool CheckCondition(StateManager state)
        {
            float timeDifference = Time.realtimeSinceStartup - state.timeSinceJump;
            if (timeDifference > 0.5f)
            {
                bool result = state.isGrounded;

                if (result)
                {
                    if (timeDifference > hardLandThreshold && timeDifference < maxLandThreshold)
                    {
                        if (state.movementVariables.moveAmount > 0.3f)
                        {
                            state.animator.CrossFade(state.hashes.LandRolling, 0.2f);
                        }
                        else
                        {
                            state.animator.CrossFade(state.hashes.LandHard, 0.2f);
                        }
                    }
                    else if (timeDifference > maxLandThreshold)
                    {
                        state.animator.CrossFade(state.hashes.LandFast, 0.2f);
                    }
                }


                return result;
            }
            else
            {
                return false;
            }
        }
    }
}