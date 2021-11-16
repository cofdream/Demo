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
            var playerInput = GameObject.Find("PlayerInput").GetComponent<PlayerInput>();
            PlayerInput.UIAction.CancelQueue.Add(Close);
            playerInput.PlayerInputAction = PlayerInput.UIAction;
        }

        public void Close()
        {
            var playerInput = GameObject.Find("PlayerInput").GetComponent<PlayerInput>();
            PlayerInput.UIAction.CancelQueue.Remove(Close);
            playerInput.PlayerInputAction = PlayerInput.PlayerAction;

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