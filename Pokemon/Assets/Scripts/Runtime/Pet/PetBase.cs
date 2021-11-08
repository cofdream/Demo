using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PetBase : ScriptableObject
{
    [SerializeField, FormerlySerializedAs("Id")] private int id;
    [SerializeField, FormerlySerializedAs("Name")] private new string name;
    [SerializeField, FormerlySerializedAs("Description")] [TextArea] private string description;

    [SerializeField, FormerlySerializedAs("FrontSprite")] private Sprite frontSprite;
    [SerializeField, FormerlySerializedAs("BackSprite")] private Sprite backSprite;

    [SerializeField, FormerlySerializedAs("Type1")] private PetType type1;
    [SerializeField, FormerlySerializedAs("Type2")] private PetType type2;

    [Header("Base Stats")]
    [SerializeField, FormerlySerializedAs("Hp")] private int hp;
    [SerializeField, FormerlySerializedAs("Attack")] private int attack;
    [SerializeField, FormerlySerializedAs("Defense")] private int defense;
    [SerializeField, FormerlySerializedAs("SpAttack")] private int spAttack;
    [SerializeField, FormerlySerializedAs("SpDefense")] private int spDefense;
    [SerializeField, FormerlySerializedAs("Speed")] private int speed;

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