using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pet
{
    [SerializeField] private PetBase petBase;
    [SerializeField] private int level;

    public Move[] moves;

    public int Hp { get; set; }
    public int MaxHp => Mathf.FloorToInt(petBase.Hp * level / 100f) + 10;
    public int Attack => Mathf.FloorToInt(petBase.Attack * level / 100f) + 5;
    public int Defense => Mathf.FloorToInt(petBase.Defense * level / 100f) + 5;
    public int SpAttack => Mathf.FloorToInt(petBase.SpAttack * level / 100f) + 5;
    public int SpDefense => Mathf.FloorToInt(petBase.SpDefense * level / 100f) + 5;
    public int Speed => Mathf.FloorToInt(petBase.Speed * level / 100f) + 5;

    public PetBase PetBase => petBase;
    public int Level => level;


    public Pet(PetBase petBase, int level)
    {
        this.petBase = petBase;
        this.level = level;

        moves = new Move[4];
        int index = 0;
        foreach (var learnableMove in petBase.LearnableMoves)
        {
            if (level >= learnableMove.Level)
            {
                moves[index] = new Move(learnableMove.MoveBase);

                if (index == 3)
                    break;
                else
                    index++;
            }
        }
    }
}