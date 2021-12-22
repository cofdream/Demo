using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] Image health;

        void Awake()
        {
            health.fillAmount = 0.5f;
        }


        public void SetHp(float hpNormalized)
        {
            health.fillAmount = hpNormalized;
        }
    }
}