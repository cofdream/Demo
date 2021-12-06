using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class UIFractory
    {
        public static T GetUI<T>() where T : class, IUI, new()
        {
            T ui = new T();
            return ui;
        }

        public static T GetBind<T>(string key) where T : MonoBehaviour
        {
            GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(key);
            go = GameObject.Instantiate(go, GameObject.Find("Canvas").transform);
            go.TryGetComponent<T>(out T bind);
            return bind;
        }
    }
}