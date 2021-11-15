using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class PetView : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] Transform content;

        [SerializeField] PetItemView petItemView;
        [SerializeField] PetMainItemView petMainItemView;

        public void Show(PetData[] petDatas)
        {
            petMainItemView.SetData(petDatas[0]);
            int length = petDatas.Length;
            for (int i = 1; i < length; i++)
            {
                var item = Instantiate(petItemView, content);
                item.SetData(petDatas[i]);

            }
        }
    }
}