using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Trainers left;
    public Trainers right;

    public int RoundNumber;

    public bool StartRound;

    public List<Trainers> Trainers;


    void Start()
    {
        RoundNumber = 0;

        Trainers = new List<Trainers>() { left, right };

        left.PutPet();
        right.PutPet();

        left.Die = Die;
        right.Die = Die;
    }

    void Update()
    {
        if (StartRound)
        {
            RoundNumber++;

            left.StartBattle(right);
            right.StartBattle(left);
        }
    }

    public void Die()
    {
        StartRound = false;
        Debug.Log("Battle End");
    }
}