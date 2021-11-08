using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LearnableMove
{
    [SerializeField] private MoveBase moveBase;
    [SerializeField] private int level;

    public MoveBase MoveBase => moveBase;
    public int Level => level;
}
