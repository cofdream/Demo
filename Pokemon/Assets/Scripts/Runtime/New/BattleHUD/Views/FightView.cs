using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    public class FightView : ViewBase
    {
        [SerializeField] Button[] btn_Skills;
        [SerializeField] Text[] txt_Skills;

        [SerializeField] Text txt_Description;

        private int selectIndex;

        public override void Show()
        {
            base.Show();

            GlobalInput.UIAction.CancelQueue.Add(CloseSelf);

            int length = battleView.PlayerPet.Skills.Length;
            for (int i = 0; i < length; i++)
            {
                var skill = battleView.PlayerPet.Skills[i];
                txt_Skills[i].text = skill.Name;
                btn_Skills[i].enabled = true;//.SetActive(true);//.interactable = true;
            }
            for (int i = length; i < 4; i++)
            {
                txt_Skills[i].text = "--";
                btn_Skills[i].enabled = false;//.gameObject.SetActive(false);// = false;
            }

            if (battleView.PlayerPet.Skills.Length != 0)
            {
                EventSystem.current.SetSelectedGameObject(btn_Skills[0].gameObject);
                SelectSkill(0);
            }
        }
        public override void Close()
        {
            base.Close();
            GlobalInput.UIAction.CancelQueue.Remove(CloseSelf);

            selectIndex = 0;
        }

        private void CloseSelf()
        {
            base.battleView.CloseFightView();
        }

        public void SelectSkill(int index)
        {
            if (index > 1)
            {
                return;
            }
            selectIndex = index;
            var skill = battleView.PlayerPet.Skills[index];
            txt_Description.text = $"PP:{skill.PP} / {skill.MaxPP}" +
                                 $"\n属性：{skill.Type}";
        }

        public void BtnSkill()
        {
            Debug.Log(selectIndex);
        }
    }
}