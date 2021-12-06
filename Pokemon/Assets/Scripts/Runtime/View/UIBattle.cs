using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pekemon
{
    public class UIBattle : IUI
    {
        private BattleMono ui;

        private CanvasGroup curCG;

        private int selectSkillIndex;

        private Trainers trainers;

        public UIBattle()
        {
            ui = UIFractory.GetBind<BattleMono>("Assets/Resource/Views/UIBattle.prefab");


            GlobalInput.UIAction.CancelQueue.Add(CloseView);
            GlobalInput.SetFirst(GlobalInput.UIAction);

            //select
            ui.btn_Fight.onClick.AddListener(SelectBtnSkill);
            ui.btn_Back.onClick.AddListener(SelectBtnBack);

            //selectSkill
            ui.SelectSkillCallback = SelectSkill;
            ui.CastSkillCallback = CastSkill;


            EventSystem.current.SetSelectedGameObject(ui.btn_Fight.gameObject);
        }

        public void Close()
        {
            GlobalInput.UIAction.CancelQueue.Remove(CloseView);

            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            ui.btn_Fight.onClick.RemoveListener(SelectBtnSkill);
            ui.btn_Back.onClick.RemoveListener(SelectBtnBack);

            GameObject.Destroy(ui.gameObject);
        }



        public void CreateTrainers(Trainers left, Trainers right)
        {
            left.roleHUD = ui.playerHUD;
            right.roleHUD = ui.enemyHUD;

            trainers = left;
            for (int i = 0; i < 4; i++)
            {
                var move = trainers.CurPet.moves[i];
                if (move == null)
                {
                    ui.txt_Skills[i].text = "--";
                    ui.btn_Skills[i].interactable = false;
                }
                else
                {
                    ui.txt_Skills[i].text = move.MoveBase.Name;
                }
            }
        }



        public void ShowSelectOperateView()
        {
            CloseView();
        }

        public IEnumerator ShowEnterBattleMask()
        {
            yield return ui.battkeMask.Play();
            Debug.Log("Mask End.");
        }
        public IEnumerator ShowRoleEnterBattle()
        {
            //显示人物进场
            ui.playerHUD.EnterBattle();
            ui.enemyHUD.EnterBattle();

            //更新动画
            bool playerEnd = false;
            bool enemyEnd = false;
            while (true)
            {
                if (playerEnd == false)
                {
                    playerEnd = ui.playerHUD.UpdateEnterBattle();
                }
                if (enemyEnd == false)
                {
                    enemyEnd = ui.enemyHUD.UpdateEnterBattle();
                }
                if (playerEnd && enemyEnd)
                {
                    break;
                }
                yield return null;
            }
        }

        public IEnumerator ZHPet(bool left)
        {
            //角色丢球动画
            RoleHUD roleHUD;
            if (left)
                roleHUD = ui.playerHUD;
            else roleHUD = ui.enemyHUD;


            yield return roleHUD.ZHPet();
        }


        private void CloseView()
        {
            if ((object)curCG != null)
            {
                ui.selectCG.alpha = 0;
                ui.selectCG.alpha = 1;
            }
        }

        //select
        private void SelectBtnSkill()
        {
            CloseSlect();

            curCG = ui.skillCG;
            ui.skillCG.alpha = 1;
            EventSystem.current.SetSelectedGameObject(ui.btn_Skills[0].gameObject);
        }
        private void SelectBtnBack()
        {
            Debug.Log("逃跑。");
        }
        private void CloseSlect()
        {
            ui.selectCG.alpha = 0;
        }


        //select skill
        private void SelectSkill(int index)
        {
            selectSkillIndex = index;

            var move = trainers.CurPet.moves[index];
            ui.txt_Description.text = move.MoveBase.Description + "\n" + move.PP.ToString() + "/" + move.MoveBase.PP.ToString();
        }
        private void CastSkill()
        {
            if (selectSkillIndex == 1)
            {
                trainers.DoCastSkill_1();
            }
            else if (selectSkillIndex == 2)
            {
                trainers.DoCastSkill_2();
            }
            else if (selectSkillIndex == 3)
            {
                trainers.DoCastSkill_3();
            }
            else if (selectSkillIndex == 4)
            {
                trainers.DoCastSkill_4();
            }
        }
    }
}
