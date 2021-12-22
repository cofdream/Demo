using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class BattleSystem : MonoBehaviour
    {
        [SerializeField] BattleUnit playerUnit;
        [SerializeField] BattleHud playerHud;

        [SerializeField] BattleUnit enemyUnit;
        [SerializeField] BattleHud enemyHud;

        // Start is called before the first frame update
        void Start()
        {
            SetupBattle();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SetupBattle()
        {
            playerUnit.Setup();
            playerHud.SetData(playerUnit.Pokemon);

            enemyUnit.Setup();
            enemyHud.SetData(enemyUnit.Pokemon);
        }
    }
}