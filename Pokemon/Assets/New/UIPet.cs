using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPet : MonoBehaviour
{
    public Text Name;
    public Text Level;
    public Text HpTxt;

    public RectTransform HP;
    public float WidthHp = 175;

    public void SetData(Pet pet)
    {
        Name.text = pet.Name;
        Level.text = pet.Level.ToString();
        HpTxt.text = $"{pet.Hp}/{pet.MaxHp}";
    }

    public void UpdatePetHp(Pet pet)
    {
        HpTxt.text = $"{pet.Hp}/{pet.MaxHp}";
    }
}