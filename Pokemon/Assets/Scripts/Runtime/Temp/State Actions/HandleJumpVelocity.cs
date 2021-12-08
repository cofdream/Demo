using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Handle Jump Velocity")]
    public class HandleJumpVelocity : StateActions
    {
        public float jumpSpeed = 4;
        public float idleJumpSpeed = 2;

        public override void Execute(StateManager states)
        {
            states.rigidbody.drag = 0;

            Vector3 currentVelocity = states.rigidbody.velocity;
            states.timeSinceJump = Time.realtimeSinceStartup;
            states.isGrounded = false;
            
            if (states.movementVariables.moveAmount > 0.1f)
            {
                states.animator.CrossFade(states.hashes.JumpForward, 0.2f);
                currentVelocity += jumpSpeed * Vector3.up;
            }
            else
            {
                states.animator.CrossFade(states.hashes.JumpIdle, 0.2f);
                currentVelocity += idleJumpSpeed * Vector3.up;
            }

            states.rigidbody.velocity = currentVelocity;
        }
    }
}
