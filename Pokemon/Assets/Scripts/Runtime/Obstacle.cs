using UnityEngine;

namespace Pekemon
{
    public class Obstacle : MonoBehaviour
    {
        public virtual bool CanMove()
        {
            return false;
        }
    }
}
