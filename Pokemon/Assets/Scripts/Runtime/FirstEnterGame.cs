using Cofdream.Asset;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class FirstEnterGame : MonoBehaviour
    {
        private IAssetLoader loader;

        public BattlePlayer Hero;
        public BattlePlayer Enemy;

        public Battle Battle;

        public PlayerData playerData;

        void Start()
        {
            //playerData = PlayerData.Instance;

            //UIManager.Get<BagView>().Show(playerData.BagData.Props);

            UIManager.Get<PetView>().Show(playerData.PetDatas);

            //StartCoroutine(BattleModle());
        }

        IEnumerator BattleModle()
        {
            //var battleView = UIManager.Get<BattleView>();

            //battleView.Text.text = "开始模拟战斗.";
            //battleView.textTypewriter.Play(0.2f);

            yield return new WaitForSeconds(1.5f);

            //battleView.Text.text = "接下里做什么.";

            loader = AssetsLoad.GetAssetLoad("Assets_Resource_Pets");

            var pet1 = loader.Load<PetBase>("Bulbasaur");
            Hero = new BattlePlayer();
            Hero.pets = new Pet[]
            {
                new Pet(pet1,5),
            };

            var pet2 = loader.Load<PetBase>("Chamander");
            Enemy = new BattlePlayer();
            Enemy.pets = new Pet[]
            {
                new Pet(pet2,5),
            };


            Battle = new Battle();

            Debug.Log("");
        }


        private void OnDestroy()
        {
            loader?.UnloadAllLoadedObjects();
        }
    }
}