using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Battle2
    {
        public static Battle2 CurBattle { get; private set; }


        public BattleView battleView;


        public static void StartBattle()
        {
            CurBattle = new Battle2();
            CurBattle.StartBattle2();
        }

        public void StartBattle2()
        {
            battleView = UIManager.Get<BattleView>();
            battleView.ShowBattleMask();
         }
    }
}
