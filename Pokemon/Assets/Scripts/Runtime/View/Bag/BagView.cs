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
            PlayerInput.UIAction.Cancel = Close;
            PlayerInput.SetFirst(PlayerInput.UIAction);
        }

        public void Close()
        {
            PlayerInput.UIAction.Cancel = null;
            PlayerInput.RemoveFirst(PlayerInput.UIAction);

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