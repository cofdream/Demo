using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class DialogBind : MonoBehaviour
    {
        public Text ContetnText;

        private bool state;
        private float timeSpace = 0.3f;
        private float time;


        private void Update()
        {
            if (state)
            {
                time += Time.deltaTime;
                if (time >= timeSpace)
                {
                    time -= timeSpace;
                    Call();
                }
            }
        }

        private void Call()
        {

        }
    }
}