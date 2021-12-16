using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    public class UIBattle 
    {
        private BattleMono ui;

        private CanvasGroup curCG;

        private int selectSkillIndex;

        private Trainers trainers;

        public UIBattle()
        {
            ui = GetBind<BattleMono>("Assets/Resource/Views/UIBattle.prefab");

            GlobalInput.SetFirst(GlobalInput.UIAction);

            //select
            ui.btn_Fight.onClick.AddListener(OpenSelectSkillView);
            ui.btn_Back.onClick.AddListener(SelectBtnBack);

            //selectSkill
            int length = ui.Skills.Length;
            for (int i = 0; i < length; i++)
            {
                var entries = ui.Skills[i].triggers;

                EventTrigger.Entry entry;

                entry = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.Select
                };

                int index = i;
                entry.callback.AddListener((BaseEventData data) =>
                {
                    selectSkillIndex = index;
                    SelectSkill();
                });
                entries.Add(entry);

                entry = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerClick
                };
                entry.callback.AddListener(CastSkill);
                entries.Add(entry);
            }

            EventSystem.current.SetSelectedGameObject(ui.btn_Fight.gameObject);
        }
        public T GetBind<T>(string key) where T : MonoBehaviour
        {
            GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(key);
            go = GameObject.Instantiate(go, GameObject.Find("MaskCanvas").transform);
            go.TryGetComponent<T>(out T bind);
            return bind;
        }
        public void Close()
        {

            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            ui.btn_Fight.onClick.RemoveListener(OpenSelectSkillView);
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
                if (move.MoveBase == null)
                {
                    ui.txt_Skills[i].text = "--";

                    ui.Skills[i].GetComponent<Button>().enabled = false;
                }
                else
                {
                    ui.txt_Skills[i].text = move.MoveBase.Name;

                    ui.Skills[i].GetComponent<Button>().enabled = true;
                }
            }
        }



        public void ShowSelectOperateView()
        {
            if ((object)curCG != null) curCG.alpha = 0;
            ui.selectCG.alpha = 1;
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


        //select
        private void OpenSelectSkillView()
        {
            ui.selectCG.alpha = 0;

            curCG = ui.selectSkillCG;
            ui.selectSkillCG.alpha = 1;
            EventSystem.current.SetSelectedGameObject(ui.Skills[0].gameObject);
            Debug.Log("select skill " + ui.Skills[0].gameObject);

        }
        private void SelectBtnBack()
        {
            Debug.Log("逃跑。");
        }


        //select skill
        private void SelectSkill()
        {
            var move = trainers.CurPet.moves[selectSkillIndex];
            ui.txt_Description.text = move.MoveBase.Description + "\n" + move.PP.ToString() + "/" + move.MoveBase.PP.ToString();
        }
        private void CastSkill(BaseEventData data)
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
