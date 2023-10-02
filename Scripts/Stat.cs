using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    public StatData data;

    public int level;
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

    private void OnEnable()
    {
        textLevel.text = "Lv." + level;
        textDesc.text = string.Format(data.statDesc, data.baseDamage);

        switch (data.statType)
        {
            case StatData.StatType.Power:
                textName.text = string.Format(data.statName, GameManager.instance.playerData.baseDamage);
                break;
            case StatData.StatType.HP:
                textName.text = string.Format(data.statName, GameManager.instance.playerData.maxHealth);
                break;
            case StatData.StatType.Armor:
                textName.text = string.Format(data.statName, GameManager.instance.playerData.Armor);
                break;
            case StatData.StatType.CP:
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriPer);
                break;
            case StatData.StatType.CD:
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
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.baseDamage);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.HP:
                GameManager.instance.playerData.maxHealth += data.baseDamage;
                GameManager.instance.playerData.health += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.maxHealth);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.Armor:
                GameManager.instance.playerData.Armor += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.Armor);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.CP:
                GameManager.instance.playerData.CriPer += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriPer);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.CD:
                GameManager.instance.playerData.CriDam += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.playerData.CriDam);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
        }
    }

}
