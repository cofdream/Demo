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


        void Start()
        {
            StartCoroutine(Run());
        }
        static IEnumerator Run()
        {
            UIBattle = UIFractory.GetUI<UIBattle>();

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

    }
}