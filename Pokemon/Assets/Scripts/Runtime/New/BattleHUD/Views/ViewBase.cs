using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup;

        public BattleView battleView;

        protected virtual void Awake()
        {
            canvasGroup.alpha = 0;
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
