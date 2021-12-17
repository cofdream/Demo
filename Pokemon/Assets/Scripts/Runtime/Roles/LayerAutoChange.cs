using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class LayerAutoChange : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;

        void Update()
        {
            spriteRenderer.sortingOrder = -1 * (int)(transform.position.y + 0.99f);
        }
    }
}