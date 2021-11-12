using Cofdream.Asset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Transform canvas;



        private static DialogBind dialogBind;

        private static UIManager instance;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var assetLoad = AssetsLoad.GetAssetLoad("Assets_Resource_UI");
            var prefab = assetLoad.Load<UIManager>("UI.prefab");
            instance = Object.Instantiate(prefab);
            Object.DontDestroyOnLoad(instance);

            instance.hideFlags = HideFlags.DontSave;

            assetLoad.UnloadAllLoadedObjects();
        }
    }
}