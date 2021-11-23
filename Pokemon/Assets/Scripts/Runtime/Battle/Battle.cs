using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{

    public class BattlePet
    {
        private Pet pet;

        private UnityAction selfDef;

        public HUDView HUDView;

        public BattlePet(Pet pet, UnityAction selfDef)
        {
            this.pet = pet;

            this.pet.Hp = this.pet.MaxHp;

            this.selfDef = selfDef;
        }

        public void Init()
        {
            HUDView.Init(this.pet.Hp);
        }

        internal void Run(BattlePet pet)
        {
            pet.Damage((int)(this.pet.Attack * 0.2f));
        }

        private void Damage(int damage)
        {
            pet.Hp -= damage;

            if (pet.Hp <= 0)
            {
                pet.Hp = 0;

                selfDef();
            }
            else
            {
                
            }

            HUDView.SetHP(pet.Hp);

        }
    }

    public class Battle : MonoBehaviour
    {
        private static Battle instance;
        public static Battle Instance => instance;

        public BattlePet pet;
        public BattlePet pet2;

        public int Round;

        public bool Next;

        IEnumerator Start()
        {
            var battleView = UIManager.Get<BattleView>();

            pet.HUDView = battleView.hUDViews[0];
            pet2.HUDView = battleView.hUDViews[1];

            pet.Init();
            pet2.Init();

            while (true)
            {
                yield return null;

                if (Next)
                {
                    Next = false;


                    pet.Run(pet2);

                    pet2.Run(pet);

                    Round++;
                }
            }
        }

        private void P1Win()
        {
            Debug.Log("p1 Win.");
            Debug.Log(Round);
            StopAllCoroutines();
        }
        private void P2Win()
        {
            Debug.Log("p2 Win.");
            Debug.Log(Round);
            StopAllCoroutines();
        }

        public static void Start1V1(Pet p1, Pet p2)
        {
            instance = new GameObject("Battle").AddComponent<Battle>();
            instance.pet = new BattlePet(p1, instance.P2Win);
            instance.pet2 = new BattlePet(p2, instance.P1Win);


        }
    }
}