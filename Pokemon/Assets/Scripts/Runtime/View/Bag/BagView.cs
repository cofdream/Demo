using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class BagView : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;

        //select


        //list
        [SerializeField] Transform content;
        [SerializeField] BagItemView bagItemView;





        private void Awake()
        {
            GlobalInput.UIAction.Cancel = Close;
            GlobalInput.SetFirst(GlobalInput.UIAction);
        }

        public void Close()
        {
            GlobalInput.UIAction.Cancel = null;
            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            UIManager.Close(gameObject);
            Destroy(gameObject);
        }

        public void Show(PropData[] props)
        {
            int length = props.Length;
            for (int i = 0; i < length; i++)
            {
                var item = Instantiate(bagItemView, content);
                item.Show(props[i]);
            }
        }
    }
}