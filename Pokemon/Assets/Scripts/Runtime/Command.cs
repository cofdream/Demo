using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public interface ICommand
    {
        void Execute();
    }

    public abstract class Command : ScriptableObject, ICommand
    {
        public abstract void Execute();
    }
}
