using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class BagView : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] Transform content;

        [SerializeField] BagItemView bagItemView;


        public void Show(PropData[] props)
        {
            int length = props.Length;
            for (int i = 0; i < length; i++)
            {
                var item = Instantiate(bagItemView, content);
                item.Show(props[i]);
            }
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}