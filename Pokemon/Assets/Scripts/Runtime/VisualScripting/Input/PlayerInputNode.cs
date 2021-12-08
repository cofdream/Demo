using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

namespace Pokemon.VS
{
    public class PlayerInputNode : Unit
    {
        [DoNotSerialize]
        public ControlInput inputTrigger;

        [DoNotSerialize]
        public ControlOutput outputTrigger;

        [DoNotSerialize]
        public ValueInput playerInput;

        [DoNotSerialize]
        public ValueInput isUpdate;

        protected override void Definition()
        {
            inputTrigger = ControlInput("inputTrigger", InputAction);
            outputTrigger = ControlOutput("outputTrigger");

            playerInput = ValueInput<PlayerInput>("PlayerInput");
        }
        private ControlOutput InputAction(Flow flow)
        {
            var playerInput2 = flow.GetValue<PlayerInput>(playerInput);

            int count = 0;
            foreach (InputAction item in playerInput2.currentActionMap.actions)
            {

                if (count == 0 && item.name == "Move")
                {
                    item.performed += OnMove;
                    count++;
                }
                else if (count == 1 && item.name == "Confirm")
                {
                    item.performed += OnConfirm;
                    count++;
                }
                else
                {
                    if (count == 2)
                    {
                        break;
                    }
                }
            }

            return outputTrigger;
        }

        public void OnConfirm(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            Debug.Log("Enter");
        }
        public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            Debug.Log($"started：{context.started}  performed：{context.performed}  canceled：{context.canceled}  value：{context.ReadValue<Vector2>()}");
        }
    }
}