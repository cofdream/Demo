using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public interface ITriggerable
    {
        void PlayerTriggerable(PlayerController playerController);
    }
}
