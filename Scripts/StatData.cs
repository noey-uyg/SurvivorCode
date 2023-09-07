using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Scriptble object/StatData")]
public class StatData : ScriptableObject
{
    public enum StatType { Power, HP, Armor, CP, CD }

    [Header("# Main Info")]
    public StatType statType;
    public int statId;
    public string statName;
    [TextArea]
    public string statDesc;
    public Sprite statIcon;

    [Header("# Level Data")]
    public float baseDamage;

    [Header("# Skill")]
    public GameObject proijectile;
}
