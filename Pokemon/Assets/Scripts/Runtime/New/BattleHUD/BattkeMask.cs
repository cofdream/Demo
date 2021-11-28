using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pekemon
{
    public class BattkeMask : MonoBehaviour
    {
        public Image img_mask;
        [Range(1, 255)]
        public float speed = 1f;

        [Range(0, 255)]
        public float endColorA = 40f;

        public void ShowMaskAnimation(UnityAction showEndCallback)
        {
            StartCoroutine(Play(showEndCallback));
        }

        private IEnumerator Play(UnityAction showEndCallback)
        {
            var color = Color.black;
            img_mask.color = color;

            endColorA /= 255f;
            while (true)
            {
                yield return null;
                var a = speed * Time.deltaTime;
                if (color.a <= endColorA)
                {
                    a = 0;
                    color.a = a;
                    img_mask.color = color;

                    showEndCallback?.Invoke();

                    yield break;
                }
                else
                {
                    color.a -= a / 255f;
                    img_mask.color = color;
                }
            }
        }
    }
}