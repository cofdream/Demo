using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainers : MonoBehaviour
{
    public Battle battle;
    public Pet pet;

    private Trainers target;

    delegate void Action();
    private List<Action> Actions;

    public Pet[] Pets;
    public int PetIndex;

    internal System.Action Die;

    public UITrainers UITrainers;

    private void Start()
    {
        Actions = new List<Action>()
        {
            Attack,
            UseProps,
            Sleep,
        };
    }

    public bool PutPet()
    {
        for (int i = 0; i < Pets.Length; i++)
        {
            if (Pets[i].Hp > 0)
            {
                pet = Pets[i];
                PetIndex = i;

                UITrainers.PutPet(pet);

                pet.Die = () =>
                {
                    if (PutPet() == false)
                    {
                        Die.Invoke();
                    }
                };

                return true;
            }
        }
        return false;
    }


    public void StartBattle(Trainers target)
    {
        this.target = target;

        int index = Random.Range(0, Actions.Count);
        Actions[index]();

        if (pet.Hp == 0)
        {
            Die.Invoke();
        }
    }

    public void Attack()
    {
        pet.Attack(target.pet);

        target.UITrainers.UpdatePetHp(target.pet);
    }
    public void UseProps()
    {
        pet.Hp += Random.Range(0, 11);
        pet.Atk += Random.Range(0, 4);
        pet.Speed += Random.Range(0, 4);

        UITrainers.UpdatePetHp(pet);
    }
    public void Sleep()
    {

    }
}