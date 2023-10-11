using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    public StatData data;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;
    Text[] texts;

    private void Awake()
    {
        texts = GetComponentsInChildren<Text>();

        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.statIcon;

        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.statName;
        textDesc.text = data.statDesc;
    }

    private void Start()
    {
        textDesc.text = string.Format(data.statDesc, data.baseDamage);

        switch (data.statType)
        {
            case StatData.StatType.Power:
                textLevel.text = "Lv." + GameManager.instance.playerData.baseDamageLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.baseDamage);
                break;
            case StatData.StatType.HP:
                textLevel.text = "Lv." + GameManager.instance.playerData.maxHealthLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.maxHealth);
                break;
            case StatData.StatType.Armor:
                textLevel.text = "Lv." + GameManager.instance.playerData.ArmorLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.Armor);
                break;
            case StatData.StatType.CP:
                textLevel.text = "Lv." + GameManager.instance.playerData.CriPerLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriPer);
                break;
            case StatData.StatType.CD:
                textLevel.text = "Lv." + GameManager.instance.playerData.CriDamLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriDam);
                break;
        }
    }

    
    public void ClickUpdate()
    {
        switch (data.statType)
        {
            case StatData.StatType.Power:
                GameManager.instance.playerData.baseDamage += data.baseDamage;
                GameManager.instance.playerData.baseDamageLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.baseDamageLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.baseDamage);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.HP:
                GameManager.instance.playerData.maxHealth += data.baseDamage;
                GameManager.instance.playerData.health += data.baseDamage;
                GameManager.instance.playerData.maxHealthLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.maxHealthLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.maxHealth);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.Armor:
                GameManager.instance.playerData.Armor += data.baseDamage;
                GameManager.instance.playerData.ArmorLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.ArmorLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.Armor);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.CP:
                GameManager.instance.playerData.CriPer += data.baseDamage;
                GameManager.instance.playerData.CriPerLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.CriPerLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriPer);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.CD:
                GameManager.instance.playerData.CriDam += data.baseDamage;
                GameManager.instance.playerData.CriDamLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.CriDamLevel;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriDam);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
        }
    }

}
