using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Mono Actions/Action Batch")]
    public class ActionBatch : Action
    {
        public Action[] actions;

        public override void Execute()
        {
            foreach (var action in actions)
            {
                action.Execute();
            }
        }
    }
}