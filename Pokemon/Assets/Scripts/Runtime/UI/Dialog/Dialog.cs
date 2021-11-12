using Cofdream.Asset;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pekemon
{
    public class Dialog
    {
        private static Transform uiCanvas;
        private static DialogBind dialogBind;


        static Dialog()
        {
            var assetLoad = AssetsLoad.GetAssetLoad("Assets_Resource_UI");


            dialogBind = assetLoad.Load<DialogBind>("Dialog.prefab");
            dialogBind = Object.Instantiate(dialogBind, uiCanvas);
            dialogBind.gameObject.hideFlags = HideFlags.DontSave;

            assetLoad.UnloadAllLoadedObjects();
        }


        public static void Show(string content, UnityEngine.Events.UnityAction playEnd = null)
        {
            dialogBind.gameObject.SetActive(true);
            dialogBind.canvasGroup.alpha = 1;
            dialogBind.ContetnText.text = content;
            dialogBind.textTypewriter.Play(0.1f);

            dialogBind.textTypewriter.PlayEnd += playEnd;
        }

        public static void Close()
        {
            dialogBind.canvasGroup.alpha = 0;
            dialogBind.gameObject.SetActive(false);
            dialogBind.textTypewriter.PlayEnd = null;
        }
    }
}