using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrainers : MonoBehaviour
{
    public UIPet Pet;

    public void PutPet(Pet pet)
    {
        Pet.SetData(pet);
    }

    public void UpdatePetHp(Pet pet)
    {
        Pet.UpdatePetHp(pet);
    }
}
