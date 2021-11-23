using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    [System.Serializable]
    public class HUDView
    {
        public Image Hp;
        private RectTransform rectTran;

        private float maxHp;

        private float widthHP;
        public void Init(int hp)
        {
            rectTran = Hp.GetComponent<RectTransform>();

            maxHp = hp;
            widthHP = rectTran.rect.width;
        }

        public void SetHP(int value)
        {
            rectTran.sizeDelta += new Vector2(value / maxHp, 0);
            Debug.Log(value);
        }


    }

    public class BattleView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup defaultView;
        [SerializeField] private CanvasGroup message;
        [SerializeField] private CanvasGroup selectMove;

        public Text Tx_Message;
        public TextTypewriter textTypewriter;


        public Button Move1;
        public Button Move2;
        public Button Move3;
        public Button Move4;


        public HUDView[] hUDViews;


        private void Awake()
        {

            Move4.onClick.AddListener(OnBack);

            GlobalInput.UIAction.ConfirmQueue.Add(ClickBtn);

            GlobalInput.SetFirst(GlobalInput.UIAction);

            EventSystem.current.SetSelectedGameObject(Move1.gameObject);


            defaultView.alpha = 1;
            defaultView.blocksRaycasts = true;

            message.alpha = 0;
            message.blocksRaycasts = false;

            selectMove.alpha = 0;
            selectMove.blocksRaycasts = false;


            Tx_Message.text = "接下来做什么？";

            Move1.onClick.AddListener(OnSelectMove);
        }


        private void OnDestroy()
        {
            GlobalInput.UIAction.ConfirmQueue.Remove(ClickBtn);

            GlobalInput.RemoveFirst(GlobalInput.UIAction);
        }


        public void Close()
        {

            UIManager.Close(gameObject);
            Destroy(gameObject);
        }


        private void ClickBtn()
        {
            var go = EventSystem.current.currentSelectedGameObject;
            if (go != null && go.TryGetComponent(out Button button))
            {
                button.onClick?.Invoke();
            }
        }

        private void OnSelectMove()
        {
            defaultView.alpha = 0;
            defaultView.blocksRaycasts = false;

            selectMove.alpha = 1;
            selectMove.blocksRaycasts = true;
        }

        private void OnBack()
        {
            Tx_Message.text = "Can you back?";
        }



    }
}
