using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PetBase : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private new string name;
    [SerializeField] [TextArea] private string description;

    [Header("外貌")]
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;

    [Header("属性")]
    [SerializeField] private PetType type1;
    [SerializeField] private PetType type2;

    [Header("种族")]
    [SerializeField] private int hp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int spAttack;
    [SerializeField] private int spDefense;
    [SerializeField] private int speed;

    [Header("招式")]
    [SerializeField] private LearnableMove[] learnableMoves;

    public int Id => id;
    public string Name => name;
    public string Description => description;

    public Sprite FrontSprite => frontSprite;
    public Sprite BackSprite => backSprite;

    public PetType Type1 => type1;
    public PetType Type2 => type2;

    public int Hp => hp;
    public int Attack => attack;
    public int Defense => defense;
    public int SpAttack => spAttack;
    public int SpDefense => spDefense;
    public int Speed => speed;

    public LearnableMove[] LearnableMoves => learnableMoves;
}