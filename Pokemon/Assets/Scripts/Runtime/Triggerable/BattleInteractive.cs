﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class BattleInteractive : MonoBehaviour, ITriggerable
    {
        [Header("player")]
        public PetBase[] petBases;
        public int[] levels;

        [Header("emeny")]
        public PetBase[] petBases2;
        public int[] levels2;

        private static bool enter;

        private void OnEnable()
        {
            enter = false;
        }

        public void PlayerTriggerable(PlayerController playerController)
        {
            if (enter)
            {
                return;
            }
            enter = true;

            Pet[] pets = new Pet[petBases.Length];

            for (int i = 0; i < petBases.Length; i++)
            {
                pets[i] = new Pet(petBases[i], levels[i]);
            }

            Pet[] pets2 = new Pet[petBases.Length];

            for (int i = 0; i < petBases.Length; i++)
            {
                pets2[i] = new Pet(petBases2[i], levels2[i]);
            }


          StartCoroutine(Battle2.StartBattle());

            //Battle.Start1V1(pets[0], pets2[0]);
        }
    }
}