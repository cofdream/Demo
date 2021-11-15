using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class Dialog : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public Text ContetnText;
        public TextTypewriter textTypewriter;

        private void Awake()
        {
            canvasGroup.alpha = 0;
        }

        public void Show(string content, UnityEngine.Events.UnityAction playEnd = null)
        {
            canvasGroup.alpha = 1;
            ContetnText.text = content;
            textTypewriter.Play(0.2f);

            textTypewriter.PlayEnd += playEnd;
        }

        public void Close()
        {
            canvasGroup.alpha = 0;
            textTypewriter.PlayEnd = null;

            UIManager.Close(gameObject);

            Destroy(gameObject);
        }
    }
}