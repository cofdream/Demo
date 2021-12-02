using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class Battle2
    {
        public static Battle2 CurBattle { get; private set; }


        public BattleView battleView;


        public static IEnumerator StartBattle()
        {
            CurBattle = new Battle2();
            yield return CurBattle.StartBattle2();
        }

        public IEnumerator StartBattle2()
        {
            isEnd = false;
            //Init
            Fight fight = new Fight();
            BPet p1 = leftPet = new BPet()
            {
                ATK = 10,
                Name = "P1",
                Hp = 40,
                MaxHp = 40,
                battle = this,
                isLeft = true,
                Skills = new Skill[]
                {
                    new Skill()
                    {
                        Name = "Zhua",
                        PP = 20,
                        MaxPP = 20,
                        Type="Normal",
                    },
                     new Skill()
                    {
                        Name = "jiao",
                        PP = 20,
                        MaxPP = 20,
                        Type="Normal",
                    },
                },
            };
            BPet p2 = rightPet = new BPet()
            {
                ATK = 10,
                Name = "P2",
                Hp = 40,
                MaxHp = 40,
                battle = this,
                isLeft = false,
                Skills = new Skill[]
                {
                    new Skill()
                    {
                        Name = "Zhua",
                        PP = 20,
                        MaxPP = 20,
                        Type="Normal",
                    },
                     new Skill()
                    {
                        Name = "jiao",
                        PP = 20,
                        MaxPP = 20,
                        Type="Normal",
                    },
                },
            };

            //init ui
            battleView = UIManager.Get<BattleView>();

            //data

            //create p1 p2
            battleView.ShoBP1(p1);
            battleView.ShoBP2(p2);

            //ui选择技能
            //p1 p2 互相释放技能
            //ui显示
            //直到某个p死亡
            //战斗结束

            // ui
            battleView.ShowBattleMask();
            // 初始化战斗数据


            //设置战斗数据
            //battleView.

            //等待玩家输入
            while (true)
            {
                if (p1.selectSkillIndex == null || p2.selectSkillIndex == null)
                {
                    yield return null;
                }

                if (p1.selectSkillIndex != null && p2.selectSkillIndex != null)
                {
                    //计算战斗
                    p1.Skills[p1.selectSkillIndex.Value].Cast(p1, this);

                    if (isEnd)
                    {
                        Debug.Log($"{diePet.Name} dide.");
                        break;
                    }

                    p2.Skills[p2.selectSkillIndex.Value].Cast(p2, this);
                    if (isEnd)
                    {
                        Debug.Log($"{diePet.Name} dide.");
                        break;
                    }
                }


                //显示结果
                yield return null;
            }

            battleView.Close();
        }

        private BPet leftPet;
        private BPet rightPet;
        public BPet GetTarget(BPet pet)
        {
            if (pet.isLeft)
            {
                return rightPet;
            }
            return leftPet;
        }


        public bool isEnd = true;
        public BPet diePet;
        public void SetDieRole(BPet pet)
        {
            isEnd = true;
            diePet = pet;
        }
    }



    public class BPet
    {

        public int ATK;
        public int Hp;
        public int MaxHp;

        public string Name;
        public bool isLeft;

        public Skill[] Skills;

        public int? selectSkillIndex = null;

        public Battle2 battle;


        public void SetActionId(int index)
        {
            Skills[index].PP--;
            selectSkillIndex = index;
        }
    }

    public class Skill
    {
        public string Name;

        public int PP;
        public int MaxPP;
        public string Type;

        public void Cast(BPet p1, Battle2 battle2)
        {
            Debug.Log("cast " + Name);

            var target = battle2.GetTarget(p1);
            var hp = target.Hp - p1.ATK;

            if (hp <= 0)
            {
                hp = 0;
                battle2.SetDieRole(target);
            }
            target.Hp = hp;
        }
    }

    public class Fight
    {

    }

}
