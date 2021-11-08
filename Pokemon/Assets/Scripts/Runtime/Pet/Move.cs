using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase MoveBase;
    public int PP;
    public Move(MoveBase moveBase)
    {
        this.MoveBase = moveBase;
        PP = moveBase.PP;
    }
}
