using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public class BagData
    {
        public PropData[] Props;
        public PropData[] Goods;
        public PropData[] LearnableSkillMachine;
        public PropData[] PetBall;
        public PropData[] PlotProp;

        public PropData[] this[PropType propType]
        {
            get
            {
                switch (propType)
                {
                    case PropType.Goods:                    return Goods;
                    case PropType.LearnableSkillMachine:    return LearnableSkillMachine;
                    case PropType.PetBall:                  return PetBall;
                    case PropType.PlotProp:                 return PlotProp;
                }
                return null;
            }
        }
    }
}