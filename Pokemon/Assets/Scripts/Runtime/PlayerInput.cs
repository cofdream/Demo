using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Pekemon
{
    public class PlayerInputAction
    {
        public List<UnityAction> ConfirmQueue;
        public List<UnityAction> CancelQueue;
        public List<UnityAction> MenuQueue;
        public List<UnityAction> SelectQueue;
        public List<UnityAction<Vector2>> MoveQueue;

        public PlayerInputAction()
        {
            ConfirmQueue = new List<UnityAction>();
            CancelQueue = new List<UnityAction>();
            MenuQueue = new List<UnityAction>();
            SelectQueue = new List<UnityAction>();
            MoveQueue = new List<UnityAction<Vector2>>();
        }
    }

    public class PlayerInput : MonoBehaviour
    {
        //private List<UnityAction> confirmQueue;
        //private List<UnityAction> cancelQueue;

        //private List<UnityAction> menuQueue;
        //private List<UnityAction> selectQueue;

        //private List<UnityAction<Vector2>> moveQueue;

        //public List<UnityAction> ConfirmQueue => confirmQueue;
        //public List<UnityAction> CancelQueue => cancelQueue;
        //public List<UnityAction> MenuQueue => menuQueue;
        //public List<UnityAction> SelectQueue => selectQueue;
        //public List<UnityAction<Vector2>> MoveQueue => moveQueue;

        public PlayerInputAction PlayerInputAction;

        public static PlayerInputAction PlayerAction = new PlayerInputAction();
        public static PlayerInputAction UIAction = new PlayerInputAction();

        private void Awake()
        {
            //confirmQueue = new List<UnityAction>();
            //cancelQueue = new List<UnityAction>();
            //menuQueue = new List<UnityAction>();
            //selectQueue = new List<UnityAction>();
            //moveQueue = new List<UnityAction<Vector2>>();
        }

        void OnConfirm()
        {
            CallEndAction(PlayerInputAction.ConfirmQueue);
        }
        void OnCancel()
        {
            CallEndAction(PlayerInputAction.CancelQueue);
        }
        void OnMenu()
        {
            CallEndAction(PlayerInputAction.MenuQueue);
        }
        void OnSelect()
        {
            CallEndAction(PlayerInputAction.SelectQueue);
        }

        void OnMove(InputValue value)
        {
            var action = PlayerInputAction.MoveQueue;

            if (action == null || action.Count == 0)
            {
                return;
            }
            action[action.Count - 1]?.Invoke(value.Get<Vector2>());
        }

        private void CallEndAction(List<UnityAction> actions)
        {
            if (actions == null || actions.Count == 0)
            {
                return;
            }
            actions[actions.Count - 1]?.Invoke();
        }
      
    }
}