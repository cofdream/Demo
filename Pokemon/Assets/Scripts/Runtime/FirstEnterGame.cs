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
            Dialog.Show("这是一段<color=red>打字机</color>文字.");


        }

        // Update is called once per frame
        void Update()
        {
           
        }
    }
}
