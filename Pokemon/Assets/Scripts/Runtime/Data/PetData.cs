using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public class PetData
    {
        public int Id;
        public int Level;
        public PetState PetState;
        public int Hp;
        public int[] PP;
    }

    public enum PetState
    {
        None,
        Poisoning,//毒
        paralysis,//麻
        burn,//烧
        Frozen,//冰
    }
}
