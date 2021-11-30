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
        [SerializeField] private ViewBase fightview;
        [SerializeField] private ViewBase selectOperateView;
        [SerializeField] private ViewBase selectMove;

        private ViewBase curView;


        [SerializeField] BattkeMask battkeMask;
        [SerializeField] RoleHUD playerHUD;
        [SerializeField] RoleHUD enemyHUD;

        public HUDView[] hUDViews;


        private void Awake()
        {
            GlobalInput.UIAction.ConfirmQueue.Add(ClickBtn);
            GlobalInput.UIAction.CancelQueue.Add(CloeCurrentView);

            GlobalInput.SetFirst(GlobalInput.UIAction);
        }


        private void OnDestroy()
        {
            GlobalInput.UIAction.ConfirmQueue.Remove(ClickBtn);
            GlobalInput.UIAction.CancelQueue.Remove(CloeCurrentView);

            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            curView?.Close();
            curView = null;
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



        internal void ShowBattleMask()
        {
            battkeMask.ShowMaskAnimation(() =>
            {
                //显示人物进场
                playerHUD.RoleEnter(playerHUD.ThrowPet);
                enemyHUD.RoleEnter(enemyHUD.ThrowPet);

                ShowSelectOperateView();

                Debug.Log("Mask End.");
            });

        }

        private void CloeCurrentView()
        {
            curView?.Close();
        }
        private void ShowView(ViewBase viewBase)
        {
            curView = viewBase;
            viewBase.Show();
        }

        public void ShowFightView()
        {
            ShowView(fightview);
        }
        public void ShowSelectOperateView()
        {
            ShowView(selectOperateView);
        }
    }
}
