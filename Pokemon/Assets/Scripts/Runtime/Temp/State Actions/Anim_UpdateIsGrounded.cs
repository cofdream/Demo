using System.Collections;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Anim Update Is Ground")]
    public class Anim_UpdateIsGrounded : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.animator.SetBool(states.hashes.isGrounded, states.isGrounded);
        }
    }
}