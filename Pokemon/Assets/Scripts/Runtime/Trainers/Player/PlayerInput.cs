using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Pekemon
{
    public class InputAction
    {
        //public List<UnityAction> ConfirmQueue;
        //public List<UnityAction> CancelQueue;
        //public List<UnityAction> MenuQueue;
        //public List<UnityAction> SelectQueue;
        //public List<UnityAction<Vector2>> MoveQueue;

        //public InputAction()
        //{
        //    ConfirmQueue = new List<UnityAction>();
        //    CancelQueue = new List<UnityAction>();
        //    MenuQueue = new List<UnityAction>();
        //    SelectQueue = new List<UnityAction>();
        //    MoveQueue = new List<UnityAction<Vector2>>();
        //}

        public string Name;

        public UnityAction Confirm;
        public UnityAction Cancel;
        public UnityAction Menu;
        public UnityAction Select;
        public UnityAction<Vector2> Move;

        public InputAction(string name)
        {
            Name = name;
        }
    }

    public class PlayerInput : MonoBehaviour
    {
        public static InputAction DefaultAction { get; private set; }
        public static InputAction PlayerAction { get; private set; }
        public static InputAction UIAction { get; private set; }

        private static Stack<InputAction> inputActions;

        static PlayerInput()
        {
            DefaultAction = new InputAction("Default");
            PlayerAction = new InputAction("Player");
            UIAction = new InputAction("UI");

            inputActions = new Stack<InputAction>(4);
            inputActions.Push(DefaultAction);
        }

        public static void SetFirst(InputAction inputAction)
        {
            if (inputActions.Count > 0 && inputActions.Peek() == inputAction)
            {
                Debug.LogWarning($"当前{typeof(InputAction)}已经在栈顶！");
                return;
            }
            inputActions.Push(inputAction);
        }
        public static void RemoveFirst(InputAction inputAction)
        {
            if (inputActions.Count > 0 && inputActions.Peek() != inputAction)
            {
                Debug.LogWarning($"当前{typeof(InputAction)}不在在栈顶！");
                return;
            }
            inputActions.Pop();
        }


        void OnConfirm()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.Confirm?.Invoke();
        }
        void OnCancel()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.Cancel?.Invoke();
        }
        void OnMenu()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.Menu?.Invoke();
        }
        void OnSelect()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.Select?.Invoke();
        }

        void OnMove(InputValue value)
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.Move?.Invoke(value.Get<Vector2>());
        }
    }
}