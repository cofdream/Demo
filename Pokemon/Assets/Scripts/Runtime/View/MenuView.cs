using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup.alpha = 1;

            UIManager.Get<BagView>();
        }

        public void Close()
        {
            UIManager.Close(gameObject);
            Destroy(gameObject);
        }


        public void OpenBag()
        {

        }
    }
}