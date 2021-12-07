using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Trainers : MonoBehaviour
    {
        public Pet[] Pets;
        public int curPetIndex;
        public Pet CurPet => Pets[curPetIndex];

        public RoleHUD roleHUD;
        internal bool UseInput;


        private void Update()
        {
            if (UseInput == false)
            {
                return;
            }
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                DoCastSkill_1();
            }
        }

        public void ZHPet()
        {
            curPetIndex = 0;

            roleHUD.SetData(CurPet.PetBase.name, CurPet.Level, (float)CurPet.Hp / CurPet.MaxHp,
               UseInput ? CurPet.PetBase.FrontSprite : CurPet.PetBase.BackSprite);
        }

        public void HitPet(int damage)
        {
            var lastHp = CurPet.Hp - damage;
            if (lastHp <= 0) lastHp = 0;

            CurPet.Hp = lastHp;
            roleHUD.SetHP((float)CurPet.Hp / CurPet.MaxHp);

            //检测死亡
            if (CurPet.Hp == 0)
            {
                Debug.Log($"{gameObject.name}的宠物死亡。");

                if (curPetIndex == Pets.Length - 1)
                {
                    Battle.EndBattle(this);
                }
                else
                {
                    Battle.EndBattle(this);
                }
            }
        }


        public void DoCastSkill_1()
        {
            var trainers = Battle.GetTarget(this);
            var pet = trainers.curPetIndex;

            trainers.HitPet(Pets[curPetIndex].Attack);

            Debug.Log($"{CurPet.PetBase.Name} 攻击 {trainers.CurPet.PetBase.Name} .");
        }
        public void DoCastSkill_2()
        {
            var trainers = Battle.GetTarget(this);
            var pet = trainers.curPetIndex;

            trainers.HitPet(Pets[curPetIndex].Attack);

            Debug.Log($"{CurPet.PetBase.Name} 攻击 {trainers.CurPet.PetBase.Name} .");
        }
        public void DoCastSkill_3()
        {
            var trainers = Battle.GetTarget(this);
            var pet = trainers.curPetIndex;

            trainers.HitPet(Pets[curPetIndex].Attack);

            Debug.Log($"{CurPet.PetBase.Name} 攻击 {trainers.CurPet.PetBase.Name} .");
        }
        public void DoCastSkill_4()
        {
            var trainers = Battle.GetTarget(this);
            var pet = trainers.curPetIndex;

            trainers.HitPet(Pets[curPetIndex].Attack);

            Debug.Log($"{CurPet.PetBase.Name} 攻击 {trainers.CurPet.PetBase.Name} .");
        }

    }
}
