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

        private ViewBase lastShowView;

        [SerializeField] BattkeMask battkeMask;
        [SerializeField] RoleHUD playerHUD;
        [SerializeField] RoleHUD enemyHUD;

        public HUDView[] hUDViews;

        public BPet PlayerPet;
        public BPet EnemyPet;

        private void Awake()
        {
            GlobalInput.UIAction.ConfirmQueue.Add(ClickBtn);

            GlobalInput.SetFirst(GlobalInput.UIAction);

            fightview.battleView = this;
            selectOperateView.battleView = this;
        }


        private void OnDestroy()
        {
            GlobalInput.UIAction.ConfirmQueue.Remove(ClickBtn);

            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            lastShowView?.Close();
            lastShowView = null;
        }


        public void Close()
        {
            lastShowView?.Close();
            lastShowView = null;

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

        private void CloseBattleMask()
        {
            battkeMask.ShowMaskAnimation(null);
        }

        public void ShowFightView()
        {
            lastShowView?.Close();

            fightview.Show();
            lastShowView = fightview;
        }
        public void CloseFightView()
        {
            lastShowView?.Close();

            selectOperateView.Show();
            lastShowView = selectOperateView;
        }

        public void ShowSelectOperateView()
        {
            lastShowView?.Close();

            selectOperateView.Show();
            lastShowView = selectOperateView;
        }

        internal void ShoBP1(BPet p1)
        {
            playerHUD.SetPet(p1);
            PlayerPet = p1;
        }

        internal void ShoBP2(BPet p2)
        {
            enemyHUD.SetPet(p2);
            EnemyPet = p2;
        }
    }
}
