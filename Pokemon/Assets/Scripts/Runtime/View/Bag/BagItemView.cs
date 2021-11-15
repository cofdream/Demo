using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class BagItemView : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] new Text name;
        [SerializeField] Text count;

        public void Show(PropData propData)
        {
            name.text = propData.id.ToString();
            count.text = "X " + propData.count.ToString();
        }
    }
}
