using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    public class FightView : ViewBase
    {
        [SerializeField] Selectable btn_1;
        [SerializeField] Selectable btn_2;
        [SerializeField] Selectable btn_3;
        [SerializeField] Selectable btn_4;

        protected override void Awake()
        {
            base.Awake();
            base.Close();
        }


        private void OnDestroy()
        {
            Close();

        }

        public override void Show()
        {
            base.Show();

            EventSystem.current.SetSelectedGameObject(btn_1.gameObject);

            GlobalInput.UIAction.ConfirmQueue.Add(Select);
        }
        public override void Close()
        {
            base.Close();

            GlobalInput.UIAction.ConfirmQueue.Remove(Select);
        }

        private void Select()
        {
            var go = EventSystem.current.currentSelectedGameObject;
            if (go == null)
            {
                Debug.LogError("select Null.");
                return;
            }
            if (btn_1.gameObject == go)
            {
                Select_1();
            }
            else if (btn_2.gameObject == go)
            {
                Select_2();
            }
            else if (btn_3.gameObject == go)
            {
                Select_3();
            }
            else if (btn_4.gameObject == go)
            {
                Select_4();
            }
            else
            {
                Debug.LogError("select not exist.");
            }
        }

        private void Select_1()
        {
            Debug.Log(1);
        }
        private void Select_2()
        {
            Debug.Log(2);
        }
        private void Select_3()
        {
            Debug.Log(3);
        }
        private void Select_4()
        {
            Debug.Log(4);
        }
    }
}