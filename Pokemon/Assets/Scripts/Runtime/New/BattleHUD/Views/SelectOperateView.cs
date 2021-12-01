using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    public class SelectOperateView : ViewBase
    {
        public Button btn_Fight;
        public Button btn_Back;


        public override void Show()
        {
            base.Show();

            EventSystem.current.SetSelectedGameObject(btn_Fight.gameObject);
        }

        public override void Close()
        {
            base.Close();
        }
    }
}
