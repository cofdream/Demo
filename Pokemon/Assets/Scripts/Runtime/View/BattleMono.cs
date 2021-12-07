using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    public class BattleMono : MonoBehaviour
    {
        public BattkeMask battkeMask;
        public RoleHUD playerHUD;
        public RoleHUD enemyHUD;

        public HUDView[] hUDViews;

        [Header("选择操作")]
        public CanvasGroup selectCG;
        public Button btn_Fight;
        public Button btn_Back;

        [Header("技能")]
        public CanvasGroup selectSkillCG;
        public EventTrigger[] Skills;
        public Text[] txt_Skills;
        public Text txt_Description;
    }
}