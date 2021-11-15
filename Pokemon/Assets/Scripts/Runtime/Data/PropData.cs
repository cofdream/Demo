using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public enum PropType
    {
        Goods,
        LearnMove,
        Ball,
        PlotGoods,
    }

    [System.Serializable]
    public class PropData
    {
        public int id;
        public PropType PropType;
        public int count;
    }
}