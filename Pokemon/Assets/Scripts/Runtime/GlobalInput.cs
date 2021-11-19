using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Pekemon
{
    public class Action<T> where T : Delegate
    {
        public Stack<Delegate> Callback;

        public Action()
        {
            Callback = new Stack<Delegate>(3);
        }
        public T Get()
        {
            if (Callback.Count > 0)
                return (T)Callback.Peek();
            return null;
        }
        public void Add(T action)
        {
            if (Callback.Count > 0)
                if (Callback.Peek() != action)
                {
                    Debug.LogWarning("栈顶相同，无法添加");
                    return;
                }

            Callback.Push(action);
        }
        public void Remove(T action)
        {
            if (Callback.Count > 0)
                if (Callback.Peek() != action)
                {
                    Debug.LogWarning("栈顶不同，无法删除。");
                }
                else
                {
                    Callback.Pop();
                }
        }
        public void Clear()
        {
            Callback.Clear();
            Debug.LogWarning("Clear!!!!!");
        }
    }


    public class InputAction
    {
        public string Name;

        public Action<UnityAction> ConfirmQueue;
        public Action<UnityAction> CancelQueue;
        public Action<UnityAction> MenuQueue;
        public Action<UnityAction> SelectQueue;
        public Action<UnityAction<Vector2>> MoveQueue;

        public InputAction()
        {
        }
        public InputAction(string name)
        {
            Name = name;

            ConfirmQueue = new Action<UnityAction>();
            CancelQueue = new Action<UnityAction>();
            MenuQueue = new Action<UnityAction>();
            SelectQueue = new Action<UnityAction>();
            MoveQueue = new Action<UnityAction<Vector2>>();
        }
    }

    public class GlobalInput : MonoBehaviour
    {
        public static InputAction DefaultAction { get; private set; }
        public static InputAction PlayerAction { get; private set; }
        public static InputAction UIAction { get; private set; }
        public static InputAction NullAction { get; private set; }


        private static Stack<InputAction> inputActions;

        static GlobalInput()
        {
            DefaultAction = new InputAction("Default");
            PlayerAction = new InputAction("Player");
            UIAction = new InputAction("UI");
            NullAction = new InputAction();

            inputActions = new Stack<InputAction>(4);

            SetFirst(DefaultAction);
        }

        public static void SetFirst(InputAction inputAction)
        {
            if (inputActions.Count > 0)
            {
                if (inputActions.Peek() == inputAction)
                {
                    Debug.LogWarning($"当前{typeof(InputAction)}已经在栈顶！");
                    return;
                }
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
                inputActions.Peek()?.ConfirmQueue.Get()?.Invoke();
        }
        void OnCancel()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.CancelQueue.Get()?.Invoke();
        }
        void OnMenu()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.MenuQueue.Get()?.Invoke();
        }
        void OnSelect()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.SelectQueue.Get()?.Invoke();
        }

        void OnMove(InputValue value)
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.MoveQueue.Get()?.Invoke(value.Get<Vector2>());
        }
    }
}