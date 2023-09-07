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
                textName.text = string.Format(data.statName, GameManager.instance.baseDamage);
                break;
            case StatData.StatType.HP:
                textName.text = string.Format(data.statName, GameManager.instance.maxHealth);
                break;
            case StatData.StatType.Armor:
                textName.text = string.Format(data.statName, GameManager.instance.Armor);
                break;
            case StatData.StatType.CP:
                textName.text = string.Format(data.statName, GameManager.instance.CriPer);
                break;
            case StatData.StatType.CD:
                textName.text = string.Format(data.statName, GameManager.instance.CriDam);
                break;
        }
    }
    
    public void ClickUpdate()
    {
        switch (data.statType)
        {
            case StatData.StatType.Power:
                GameManager.instance.baseDamage += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.baseDamage);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.HP:
                GameManager.instance.maxHealth += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.maxHealth);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.Armor:
                GameManager.instance.Armor += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.Armor);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.CP:
                GameManager.instance.CriPer += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.CriPer);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
            case StatData.StatType.CD:
                GameManager.instance.CriDam += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textName.text = string.Format(data.statName, GameManager.instance.CriDam);
                textDesc.text = string.Format(data.statDesc, data.baseDamage);
                break;
        }
    }

}
