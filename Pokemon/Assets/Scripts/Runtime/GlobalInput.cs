using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Pekemon
{
    //public class Action<T> where T : Delegate
    //{
    //    private Stack<Delegate> Callback;

    //    public Action()
    //    {
    //        Callback = new Stack<Delegate>(3);
    //    }
    //    public T Get()
    //    {
    //        if (Callback.Count > 0)
    //            return (T)Callback.Peek();
    //        return null;
    //    }
    //    public void Add(T action)
    //    {
    //        if (Callback.Count > 0)
    //            if (Callback.Peek() == action)
    //            {
    //                Debug.LogError("栈顶相同，无法添加");
    //                return;
    //            }

    //        Callback.Push(action);
    //    }
    //    public void Remove(T action)
    //    {
    //        if (Callback.Count > 0)
    //            if (Callback.Peek() != action)
    //            {
    //                Debug.LogError("栈顶不同，无法删除。");
    //            }
    //            else
    //            {
    //                Callback.Pop();
    //            }
    //    }
    //    public void Clear()
    //    {
    //        Callback.Clear();
    //        Debug.LogWarning("Clear!!!!!");
    //    }
    //}
    //void OnConfirm()
    //{
    //    if (inputActions.Count > 0)
    //        inputActions.Peek()?.ConfirmQueue.Get()?.Invoke();
    //}
    //void OnCancel()
    //{
    //    if (inputActions.Count > 0)
    //        inputActions.Peek()?.CancelQueue.Get()?.Invoke();
    //}
    //void OnMenu()
    //{
    //    if (inputActions.Count > 0)
    //        inputActions.Peek()?.MenuQueue.Get()?.Invoke();
    //}
    //void OnSelect()
    //{
    //    if (inputActions.Count > 0)
    //        inputActions.Peek()?.SelectQueue.Get()?.Invoke();
    //}

    //void OnMove(InputValue value)
    //{
    //    if (inputActions.Count > 0)
    //        inputActions.Peek()?.MoveQueue.Get()?.Invoke(value.Get<Vector2>());
    //}


    public class Action<T> where T : Delegate
    {
        private readonly List<Delegate> callbacks;
        public List<Delegate> Callbacks => callbacks;

        public Action()
        {
            callbacks = new List<Delegate>(3);
        }

        public void Add(T action)
        {
            if (callbacks.Contains(action))
            {
                Debug.Log("已存在，无法重复添加。");
            }
            else
            {
                callbacks.Add(action);
            }
        }
        public void Remove(T action)
        {
            if (callbacks.Remove(action) == false)
            {
                Debug.Log("不存在，无法删除。");
            }
        }
        public void Clear()
        {
            callbacks.Clear();
            Debug.Log("Clear Input Action !!!!!");
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

        private static void Invoke(Action<UnityAction> action)
        {
            int length = action.Callbacks.Count;
            for (int i = 0; i < length; i++)
            {
                ((UnityAction)action.Callbacks[i]).Invoke();
            }
        }
        private static void Invoke(Action<UnityAction<Vector2>> action, Vector2 value)
        {
            int length = action.Callbacks.Count;
            for (int i = 0; i < length; i++)
            {
                ((UnityAction<Vector2>)action.Callbacks[i]).Invoke(value);
            }
        }

        public void ConfirmInvoke()
        {
            Invoke(ConfirmQueue);
        }
        public void CancelInvoke()
        {
            Invoke(CancelQueue);
        }
        public void MenuInvoke()
        {
            Invoke(MenuQueue);
        }
        public void SelectInvoke()
        {
            Invoke(SelectQueue);
        }
        public void MoveInvoke(Vector2 value)
        {
            Invoke(MoveQueue, value);
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
                    Debug.LogError($"当前{typeof(InputAction)}已经在栈顶！");
                    return;
                }
            }

            inputActions.Push(inputAction);
        }
        public static void RemoveFirst(InputAction inputAction)
        {
            if (inputActions.Peek() != inputAction)
            {
                Debug.LogError($"当前{typeof(InputAction)}不在在栈顶！");
                return;
            }

            inputActions.Pop();
        }


        void OnConfirm()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.ConfirmInvoke();
        }
        void OnCancel()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.CancelInvoke();
        }
        void OnMenu()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.MenuInvoke();
        }
        void OnSelect()
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.SelectInvoke();
        }

        void OnMove(InputValue value)
        {
            if (inputActions.Count > 0)
                inputActions.Peek()?.MoveInvoke(value.Get<Vector2>());
        }

#pragma warning disable CS0219 // 变量已被赋值，但从未使用过它的值
        private void Update()
        {
            //断点用
            GlobalInput globalInput = this;
            int a = 1;
        }
#pragma warning restore CS0219 // 变量已被赋值，但从未使用过它的值
    }
}