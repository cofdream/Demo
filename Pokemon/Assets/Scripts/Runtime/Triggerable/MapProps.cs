using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class MapProps : MonoBehaviour, ITriggerable
    {
        public void PlayerTriggerable(PlayerController2 playerController)
        {
            var dialog = UIManager.Get<Dialog>();

            dialog.Show("获取物品：？？？ X 1.", dialog.Close);
        }
    }
}