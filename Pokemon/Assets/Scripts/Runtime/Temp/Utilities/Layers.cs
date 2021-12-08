using System.Collections;
using UnityEngine;

namespace SA
{
    public static class Layers
    {
        public static LayerMask ignoreLayerController;

        static Layers()
        {
            ignoreLayerController = ~(1 << 3 | 1 << 8);
        }
    }
}