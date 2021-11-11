using Cofdream.Asset;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class FirstEnterGame : MonoBehaviour
    {
        private IAssetLoader loader;

        private Plot plot;
        private int index;
        private bool next;

        void Start()
        {
            loader = AssetsLoad.GetAssetLoad("Assets/Resource/Plot");
            plot = loader.Load<Plot>("1_FirstEnterGame.asset");

            index = 0;
            Dialog.Show(plot.content[index], PlayNext);

        }

        private void PlayNext()
        {
            next = true;
        }

        void Update()
        {
            if (next && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X)))
            {
                
                index++;
                if (index >= plot.content.Length)
                {

                    plot = plot.next;

                    next = false;
                }
                else
                {
                    Dialog.Show(plot.content[index], PlayNext);
                }
            }
        }

        private void OnDestroy()
        {
            loader.UnloadAllLoadedObjects();
        }
    }
}
