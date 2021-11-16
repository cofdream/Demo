using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public enum PropType
    {
        Goods,
        LearnableSkillMachine,
        PetBall,
        PlotProp,
    }

    [System.Serializable]
    public class PropData
    {
        public int id;
        public int count;
    }
}