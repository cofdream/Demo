using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //Init
            Fight fight = new Fight();
            BPet p1 = new BPet()
            {
                Name = "P1",
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
            BPet p2 = new BPet()
            {
                Name = "P2",
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

            //计算战斗


            //显示结果
            while (true)
            {
                

                yield return null;
            }

        }
    }

    public class BPet
    {
        public int Hp;
        public int MaxHp;

        public string Name;

        public Skill[] Skills;
    }
    public class Skill
    {
        public string Name;

        public int PP;
        public int MaxPP;
        public string Type;
    }

    public class Fight
    {

    }



}
