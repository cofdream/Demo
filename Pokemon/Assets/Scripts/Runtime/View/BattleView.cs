using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class BattleView : MonoBehaviour
    {
        public Text Tx_Message;
        public TextTypewriter textTypewriter;

        public Button Move1;
        public Button Move2;
        public Button Move3;
        public Button Btn_Back;

        private void Awake()
        {

            Btn_Back.onClick.AddListener(OnBack);
        }



        public void Close()
        {


            UIManager.Close(gameObject);
            Destroy(gameObject);
        }


        private void OnBack()
        {
            Tx_Message.text = "Can you back?";
        }
    }
}
