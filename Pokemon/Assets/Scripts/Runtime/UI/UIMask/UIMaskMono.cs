using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class UIMaskMono : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;
        public Image Img_Mask;

        [Range(1, 255)]
        public float speed = 1f;

        [Range(0, 255)]
        public float endColorA = 40f;


        public IEnumerator Play()
        {
            var color = Color.black;
            Img_Mask.color = color;

            endColorA /= 255f;
            while (true)
            {
                yield return null;
                var a = speed * Time.deltaTime;
                if (color.a <= endColorA)
                {
                    a = 0;
                    color.a = a;
                    Img_Mask.color = color;
                    break;
                }
                else
                {
                    color.a -= a / 255f;
                    Img_Mask.color = color;
                }
            }
        }

    }
}