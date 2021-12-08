using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class BattleInteractive : MonoBehaviour, ITriggerable
    {
        public PetBase[] petBases;
        public int[] levels;

        public void PlayerTriggerable(PlayerController2 playerController)
        {
            var trainersPlayer = new GameObject("Player Trainers").AddComponent<Trainers>();
            trainersPlayer.Pets = playerController.pets;

            var trainersNPC = new GameObject("NPC Trainers").AddComponent<Trainers>();
            int length = petBases.Length;
            var pets = new Pet[length];
            for (int i = 0; i < length; i++)
            {
                pets[i] = new Pet(petBases[i], levels[i]);
            }
            trainersNPC.Pets = pets;

            foreach (var item in trainersPlayer.Pets)
                item.Hp = item.MaxHp;

            foreach (var item in trainersNPC.Pets)
                item.Hp = item.MaxHp;

            Battle.CreateBattleWord(trainersPlayer, trainersNPC);
        }
    }
}