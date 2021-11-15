using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class PetMainItemView : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] new Text name;
        [SerializeField] Text hp;
        [SerializeField] Text state;

        public void SetData(PetData petData)
        {
            name.text = petData.Id.ToString();
            hp.text = petData.Hp.ToString();
            state.text = petData.PetState.ToString();
        }
    }
}
