using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class MapProps : MonoBehaviour, IInteractive
    {
        public void Execute()
        {
            Dialog.Show("获取物品：？？？ X 1.", Dialog.Close);
        }
    }
}
