using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class DialogBind : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public Text ContetnText;
        public TextTypewriter textTypewriter;

        private void Awake()
        {
            canvasGroup.alpha = 0;
        }
    }
}