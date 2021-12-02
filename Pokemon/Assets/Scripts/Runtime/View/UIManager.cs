using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Transform canvas;
        [SerializeField] private UIConfig uiConfig;

        private List<GameObject> uiClones;

        private static UIManager instance;

        private void Awake()
        {
            //Object.DontDestroyOnLoad(this);

            uiClones = new List<GameObject>();

            instance = this;
        }

        public static T Get<T>() where T : MonoBehaviour
        {
            string typeName = typeof(T).Name;
            foreach (var item in instance.uiConfig.ui)
            {
                if (item.TypeName == typeName)
                {
                    var go = Object.Instantiate(item.Prefab, instance.canvas);
                    //instance.uiClones.Add(go);
                    return go.GetComponent<T>();
                }
            }
            return default;
        }

        public static void Close(GameObject ui)
        {
            //instance.uiClones.Remove(ui);
            
        }
    }
}