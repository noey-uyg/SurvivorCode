using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristic : MonoBehaviour
{
    public CharacteristicData data;

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
    void Start()
    {
        textDesc.text = string.Format(data.CharacteristicDesc, data.baseDamage * 100);

        switch (data.characteristicType)
        {
            case CharacteristicData.CharacteristicType.Gold:
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaGoldAmountLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaGoldAmount * 100);
                break;
            case CharacteristicData.CharacteristicType.BossDamage:
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaBossDamageLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaBossDamage * 100);
                break;
            case CharacteristicData.CharacteristicType.MonsterDamage:
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaMonsterDamageLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaMonsterDamage * 100);
                break;
            case CharacteristicData.CharacteristicType.shoe:
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaMoveSpeedLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaMoveSpeed * 100);
                break;
            case CharacteristicData.CharacteristicType.HPDrain:
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaHPDrainLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaHPDrain * 100);
                break;
        }
    }

    public void OnClick()
    {
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);

        if (GameManager.instance.playerData.traitspoints < 1)
            return;

        switch (data.characteristicType)
        {
            case CharacteristicData.CharacteristicType.Gold:
                GameManager.instance.playerData.ChaGoldAmount += data.baseDamage;
                GameManager.instance.playerData.ChaGoldAmountLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaGoldAmountLevel;
                textNow.text = string.Format("{0:F1}%",GameManager.instance.playerData.ChaGoldAmount * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.BossDamage:
                GameManager.instance.playerData.ChaBossDamage += data.baseDamage;
                GameManager.instance.playerData.ChaBossDamageLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaBossDamageLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaBossDamage * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.MonsterDamage:
                GameManager.instance.playerData.ChaMonsterDamage += data.baseDamage;
                GameManager.instance.playerData.ChaMonsterDamageLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaMonsterDamageLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaMonsterDamage * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.shoe:
                GameManager.instance.playerData.ChaMoveSpeed += data.baseDamage;
                GameManager.instance.playerData.ChaMoveSpeedLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaMoveSpeedLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaMoveSpeed * 100);
                GameManager.instance.playerData.traitspoints--;
                break;
            case CharacteristicData.CharacteristicType.HPDrain:
                GameManager.instance.playerData.ChaHPDrain += data.baseDamage;
                GameManager.instance.playerData.ChaHPDrainLevel++;
                textLevel.text = "Lv." + GameManager.instance.playerData.ChaHPDrainLevel;
                textNow.text = string.Format("{0:F1}%", GameManager.instance.playerData.ChaHPDrain * 100);
                GameManager.instance.playerData.traitspoints--;
                break;

        }
        

    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
