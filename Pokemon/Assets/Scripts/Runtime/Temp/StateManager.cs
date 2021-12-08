using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class StateManager : MonoBehaviour
    {
        public float health;

        public State currentState;

        public MovementVariables movementVariables;

        [HideInInspector]
        public float delta;
        [HideInInspector]
        public Transform mTransform;
        [HideInInspector]
        public new Rigidbody rigidbody;
        [HideInInspector]
        public Animator animator;

        public AnimatorHashes hashes;
        public AnimatorData animatorData;

        public bool isVaulting;
        public VaultData vaultData;

        public bool isJumping;
        public bool isGrounded;

        [HideInInspector]
        public float timeSinceJump;

        private void Start()
        {
            mTransform = this.transform;
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            hashes = new AnimatorHashes();
            animatorData = new AnimatorData(animator);
        }

        private void Update()
        {
            delta = Time.deltaTime;

            if (currentState != null)
            {
                currentState.Tick(this);
            }
        }
        private void FixedUpdate()
        {
            delta = Time.deltaTime;

            if (currentState != null)
            {
                currentState.FixedTick(this);
            }
        }
    }
}