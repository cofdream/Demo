using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Command_SetName : Command
    {
        [SerializeField, TextArea] private string description;

        public override void Execute()
        {

        }
    }
}
