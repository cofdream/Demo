using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class FirstEnterGame : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Dialog.Init();
            Dialog.Show("");
        }

        // Update is called once per frame
        void Update()
        {
           
        }
    }
}
