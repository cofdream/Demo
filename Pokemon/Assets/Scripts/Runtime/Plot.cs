using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Plot : ScriptableObject
    {
        [SerializeField, TextArea] private string description;
        [TextArea(3, 6)] public string[] content;
        public string command;

        public Command Command;

        public Plot next;

    }
}
