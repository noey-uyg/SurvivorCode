using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristic", menuName = "Scriptble object/CharacteristicData")]
public class CharacteristicData : ScriptableObject
{
    public enum CharacteristicType {Gold, BossDamage, MonsterDamage, shoe, HPDrain}

    [Header("# Main Info")]
    public CharacteristicType characteristicType;
    public int CharacteristicId;
    public string CharacteristicName;
    [TextArea]
    public string CharacteristicDesc;
    public Sprite CharacteristicIcon;

    [Header("# Level Data")]
    public float baseDamage;


    [Header("# Skill")]
    public GameObject proijectile;
}
