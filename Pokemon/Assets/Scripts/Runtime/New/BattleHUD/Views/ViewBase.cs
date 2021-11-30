using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup;

        protected virtual void Awake()
        {
            
        }
        public virtual void Show()
        {
            canvasGroup.alpha = 1;
        }
        public virtual void Close()
        {
            canvasGroup.alpha = 0;
        }
    }
}
