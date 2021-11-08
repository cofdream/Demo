using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveBase : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField, TextArea] private string description;

    //[SerializeField] MoveDamageType
    [SerializeField, FormerlySerializedAs("PP")] private int pp;

    public string Name => name;
    public string Description => description;
    public int PP => pp;
}
//public enum MoveDamageType
//{
//    Physics,
//    Magic,
//}