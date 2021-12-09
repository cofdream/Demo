using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public string Name;
    public int Level;

    public int MaxHp;

    public int Hp;
    public int Atk;
    public int Speed;

    public System.Action Die;

    public void Attack(Pet pet)
    {
        pet.BeAttack(Atk);
    }

    public void BeAttack(int atk)
    {
        Hp -= atk;
        if (Hp <= 0)
        {
            Hp = 0;

            Die.Invoke();
        }
    }
}