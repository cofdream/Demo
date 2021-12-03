using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class UIConfig : ScriptableObject
    {
        public UIStyle[] ui;
    }

    [System.Serializable]
    public class UIStyle
    {
        public GameObject Prefab;
        public string TypeName;
    }

}