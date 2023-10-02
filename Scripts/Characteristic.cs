using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristic : MonoBehaviour
{
    public CharacteristicData data;
    public int level;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;
    Text textNow;
    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.CharacteristicIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textNow = texts[3];
        textName.text = data.CharacteristicName;
    }
    private void OnEnable()
    {
        textLevel.text = "Lv." + level;
        textDesc.text = string.Format(data.CharacteristicDesc, data.baseDamage * 100);
        
    }


    public void OnClick()
    {
        if (GameManager.instance.playerData.traitspoints < 1)
            return;

        switch (data.characteristicType)
        {
            case CharacteristicData.CharacteristicType.Gold:
                GameManager.instance.playerData.ChaGoldAmount += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textNow.text = string.Format("{0:F1}%",GameManager.instance.playerData.ChaGoldAmount * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.BossDamage:
                GameManager.instance.playerData.ChaBossDamage += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaBossDamage * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.MonsterDamage:
                GameManager.instance.playerData.ChaMonsterDamage += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaMonsterDamage * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.shoe:
                GameManager.instance.playerData.ChaMoveSpeed += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaMoveSpeed * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.HPDrain:
                GameManager.instance.playerData.ChaHPDrain += data.baseDamage;
                level++;
                textLevel.text = "Lv." + level;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaHPDrain * 100);
                GameManager.instance.playerData.traitspoints--;
                break;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
