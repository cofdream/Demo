using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class AnimatorHashes 
    {
        public int vertical = Animator.StringToHash("vertical");
        public int horizontal = Animator.StringToHash("horizontal");
        public int leftFootForward = Animator.StringToHash("leftFootForward");
        public int JumpForward = Animator.StringToHash("Jump Forward");
        public int JumpIdle = Animator.StringToHash("Jump Idle");
        public int isGrounded = Animator.StringToHash("isGrounded");
        public int LandFast = Animator.StringToHash("LandFast");
        public int LandHard = Animator.StringToHash("LandHard");
        public int LandRolling = Animator.StringToHash("LandRolling");

        public int isInteracting;
        public int VaultWalk;
    }

}