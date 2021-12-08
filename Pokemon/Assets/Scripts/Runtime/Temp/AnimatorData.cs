using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimatorData
    {
        public Transform leftFoot;
        public Transform rightFoot;
        public AnimatorData(Animator animator)
        {
            leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
            rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
        }
    }
}
