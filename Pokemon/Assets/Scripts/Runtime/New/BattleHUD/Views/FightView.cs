using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    public class FightView : ViewBase
    {
        [SerializeField] Button btn_1;
        [SerializeField] Button btn_2;
        [SerializeField] Button btn_3;
        [SerializeField] Button btn_4;


        public override void Show()
        {
            base.Show();

            EventSystem.current.SetSelectedGameObject(btn_1.gameObject);

            GlobalInput.UIAction.CancelQueue.Add(CloseSelf);
        }
        public override void Close()
        {
            base.Close();
            GlobalInput.UIAction.CancelQueue.Remove(CloseSelf);
        }

        private void CloseSelf()
        {
            base.battleView.CloseFightView();
        }

        public void Btn1()
        {
            Debug.Log(1);
        }
        public void Btn2()
        {
            Debug.Log(2);
        }
        public void Btn3()
        {
            Debug.Log(3);
        }
        public void Btn4()
        {
            Debug.Log(4);
        }
    }
}