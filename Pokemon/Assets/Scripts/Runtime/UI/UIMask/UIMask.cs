using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class UIMask : IUI
    {
        private UIMaskMono ui;

        public UIMask()
        {
            ui = GetBind<UIMaskMono>("Assets/Resource/Views/UIMask.prefab");
        }

        public  T GetBind<T>(string key) where T : MonoBehaviour
        {
            GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(key);
            go = GameObject.Instantiate(go, GameObject.Find("MaskCanvas").transform);
            go.TryGetComponent<T>(out T bind);
            return bind;
        }

        public void Show()
        {
            ui.StartCoroutine(ui.Play());
        }

    }
}