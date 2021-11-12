using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Interactive : MonoBehaviour
    {
       [SerializeField] private PlayerController playerController;

        void OnConfirm()
        {
            if (playerController.IsMoving) return;

            var collider2D = Physics2D.OverlapCircle(playerController.ForwardPoint, 0.4f, LayerMask.GetMask("Triggerable"));
            if (collider2D != null)
            {
                var interactive = collider2D.GetComponent<IInteractive>();
                if (interactive != null)
                {
                    interactive.Execute();
                }
            }
        }
    }
}