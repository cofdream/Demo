using Cofdream.AssetLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Dialog
    {
        private static Transform uiRoot;
        private static GameObject dialogGO;

        public static void Init()
        {
            var assetLoad = AssetsLoad.GetAssetLoad("Assets_Resource_UI");

            GameObject ui = assetLoad.Load<GameObject>("UI.prefab");
            ui = Object.Instantiate(ui);

            Object.DontDestroyOnLoad(ui);
            ui.hideFlags = HideFlags.DontSave;
            uiRoot = ui.transform;

            dialogGO = assetLoad.Load<GameObject>("Dialog.prefab");
            dialogGO = Object.Instantiate(dialogGO, uiRoot);
            dialogGO.hideFlags = HideFlags.DontSave;

            assetLoad.UnAllLoad();
        }

        public static void Show(string content)
        {
            dialogGO.SetActive(true);
        }

    }
}
