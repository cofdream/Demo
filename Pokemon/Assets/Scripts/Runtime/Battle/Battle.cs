using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class Battle : MonoBehaviour
    {
        public static UIBattle UIBattle;
        public static Trainers left;
        public static Trainers right;

        public static void CreateBattleWord(Trainers p1, Trainers p2)
        {
            left = p1;
            right = p2;
            new GameObject("Battle").AddComponent<Battle>();
        }
        public static Trainers GetTarget(Trainers trainers)
        {
            if (trainers == left)
            {
                return right;
            }
            else
            {
                return left;
            }
        }
        public static void EndBattle(Trainers trainers)
        {
            Debug.Log($"{trainers.gameObject.name}没有可以继续战斗的宠物了。");
            Debug.Log("战斗结束");

            UIBattle.Close();
            UIBattle = null;
        }


        static IEnumerator Run()
        {
            //UIBattle = UIFractory.GetUI<UIBattle>();

            right.UseInput = true;

            UIBattle.CreateTrainers(left, right);


            Debug.Log("wait trainers input.");

            yield return UIBattle.ShowEnterBattleMask();

            yield return UIBattle.ShowRoleEnterBattle();

            Debug.Log("start battle.");

            left.ZHPet();
            yield return UIBattle.ZHPet(true);

            right.ZHPet();
            yield return UIBattle.ZHPet(false);

            UIBattle.ShowSelectOperateView();

            yield return null;
        }


        public bool run;

        [SerializeField] Team leftTeam;
        [SerializeField] Team rightTeam;


        void Start()
        {
            //StartCoroutine(Run());

            //设置战斗宠物
            leftTeam.BattlePet = leftTeam.Trainers.Pets[0];
            rightTeam.BattlePet = rightTeam.Trainers.Pets[0];
        }

        private void Update()
        {
            if (run == false) return;

            if (leftTeam.SelectMove != null && rightTeam.SelectMove != null)
            {
                
            }
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical(new GUIContent("Left"), "box");
                {
                    GUILayout.Space(20);

                    var moves = leftTeam.BattlePet.moves;
                    for (int i = 0; i < moves.Length; i++)
                    {
                        if (GUILayout.Button(moves[i].MoveBase.Name))
                        {
                            leftTeam.SelectMove = moves[i];
                        }
                    }
                }
                GUILayout.EndVertical();

                GUILayout.BeginVertical(new GUIContent("Right"), "box");
                {
                    GUILayout.Space(20);

                    var moves = rightTeam.BattlePet.moves;
                    for (int i = 0; i < moves.Length; i++)
                    {
                        if (GUILayout.Button(moves[i].MoveBase.Name))
                        {
                            rightTeam.SelectMove = moves[i];
                        }
                    }
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }


        public BattleUnit PlayerUnit;
        public BattleUnit EnemyUnit;

        public void Setup()
        {

        }
    }
    [System.Serializable]
    public class Team
    {
        [SerializeReference] public Trainers Trainers;
        [SerializeReference] public Pokemon BattlePet;
        [SerializeReference] public Move SelectMove;
    }
}