using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public class BattlePet
    {
        public int Hp;
        public int MaxHp;
        public int Attack;
        public int Defense;
        public int Speed;

        public int Skill_Atk;

    }


    public interface IMove
    {
        void Exturce(BattleInfo battleInfo);
    }

    public class Move : IMove
    {
        public void Exturce(BattleInfo battleInfo)
        {
            BattlePet executor = battleInfo.Executor;
            BattlePet target = battleInfo.selectionTargets[0];

            int damage = executor.Attack - target.Defense;
            target.Hp -= damage;

            if (target.Hp <= 0)
            {
                target.Hp = 0;
            }
        }
    }

    public class SkillMove : IMove
    {
        public void Exturce(BattleInfo battleInfo)
        {
            BattlePet executor = battleInfo.Executor;
            BattlePet target = battleInfo.selectionTargets[0];

            int damage = executor.Attack + executor.Skill_Atk - target.Defense;
            target.Hp -= damage;

            if (target.Hp <= 0)
            {
                target.Hp = 0;
            }
        }
    }


    public class BattleInfo
    {
        public BattlePet Executor;
        public BattlePet[] selectionTargets;
    }

    public class Battle : MonoBehaviour
    {
        public BattlePet p1;
        public BattlePet p2;

        public BattleInfo p1Info;
        public BattleInfo p2Info;


        public Trainers t1;
        public Trainers t2;


        IEnumerator Start()
        {
            while (true)
            {
                yield return null;

                if (IsExturceMove())
                {
                    if (p1.Speed > p2.Speed)
                    {
                        p1Move.Exturce(p1Info);
                        if (p1.Hp == 0)
                        {
                            Debug.Log("P1 Die.");
                            yield break;
                        }
                        if (p2.Hp == 0)
                        {
                            Debug.Log("P2 Die.");
                            yield break;
                        }

                        p2Move.Exturce(p2Info);
                        if (p1.Hp == 0)
                        {
                            Debug.Log("P1 Die.");
                            yield break;
                        }
                        if (p2.Hp == 0)
                        {
                            Debug.Log("P2 Die.");
                            yield break;
                        }
                    }
                    else
                    {
                        p2Move.Exturce(p2Info);
                        if (p1.Hp == 0)
                        {
                            Debug.Log("P1 Die.");
                            yield break;
                        }
                        if (p2.Hp == 0)
                        {
                            Debug.Log("P2 Die.");
                            yield break;
                        }

                        p1Move.Exturce(p1Info);
                        if (p1.Hp == 0)
                        {
                            Debug.Log("P1 Die.");
                            yield break;
                        }
                        if (p2.Hp == 0)
                        {
                            Debug.Log("P2 Die.");
                            yield break;
                        }
                    }

                    ClearSelect();
                }
            }

        }

        private bool IsExturceMove()
        {
            if (p1Move != null && p2Move != null && p1Info != null && p2Info != null)
            {
                return true;
            }
            return false;
        }
        private void ClearSelect()
        {
            p1Move = null;
            p1Info = null;

            p2Move = null;
            p2Info = null;
        }


        public static IMove p1Move;
        public static IMove p2Move;

        private void OnGUI()
        {
            GUILayout.Label("P1------");

            if (GUILayout.Button("P1 攻击"))
            {
                p1Move = new Move();

                p1Info = new BattleInfo()
                {
                    Executor = p1,
                    selectionTargets = new BattlePet[] { p2 },
                };

            }

            if (GUILayout.Button("P1 Cast Skill"))
            {
                p1Move = new SkillMove();

                p1Info = new BattleInfo()
                {
                    Executor = p1,
                    selectionTargets = new BattlePet[] { p2 },
                };
            }


            GUILayout.Label("P2------");

            if (GUILayout.Button("P2 攻击"))
            {
                p2Move = new Move();

                p2Info = new BattleInfo()
                {
                    Executor = p2,
                    selectionTargets = new BattlePet[] { p1 },
                };
            }


            if (GUILayout.Button("P2 Cast Skill"))
            {
                p2Move = new SkillMove();

                p2Info = new BattleInfo()
                {
                    Executor = p2,
                    selectionTargets = new BattlePet[] { p1 },
                };
            }
        }

        public static void Start1V1(Trainers t1, Trainers t2)
        {
            var battle = new GameObject("Battle").AddComponent<Battle>();
            battle.t1 = t1;
            battle.t2 = t2;

            UIManager.Get<BattleView>();
        }
    }
}