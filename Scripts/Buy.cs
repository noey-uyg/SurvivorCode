using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public enum ButtonType {bosscoin, traitspoints, skill}
    public ButtonType buttonType;

    public ItemData[] item;
    Text textCount;
    Text textCost;

    int bosscoinCost;
    int traitspointsCost;

    int PrevSkillCost = 0;
    int NextSkillCost = 1;
    int temp = 0;

    private void Awake()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        textCount = texts[0];
        textCost = texts[2];
    }

    private void LateUpdate()
    {
        bosscoinCost = (12+GameManager.instance.playerData.Wave)* GameManager.instance.playerData.Wave;
        traitspointsCost = (31 + GameManager.instance.playerData.Wave) * GameManager.instance.playerData.Wave;

        switch (buttonType)
        {
            case ButtonType.bosscoin:
                textCount.text = string.Format("{0}",3 * GameManager.instance.playerData.Wave);
                textCost.text = string.Format("골드 {0}소모", bosscoinCost);
                break;
            case ButtonType.traitspoints:
                textCount.text = string.Format("{0}", 1 * GameManager.instance.playerData.Wave + GameManager.instance.playerData.level);
                textCost.text = string.Format("골드 {0}소모", traitspointsCost);
                break;
            case ButtonType.skill:
                textCost.text = string.Format("보스재화 {0}소모", NextSkillCost);
                break;
        }

    }
    public void Onclick()
    {
        switch (buttonType)
        {
            case ButtonType.bosscoin:
                if (bosscoinCost <= GameManager.instance.playerData.gold)
                {
                    GameManager.instance.playerData.bosspoint += (3 * GameManager.instance.playerData.Wave);
                    GameManager.instance.playerData.gold -= bosscoinCost;
                }
                
                break;
            case ButtonType.traitspoints:
                if(traitspointsCost<= GameManager.instance.playerData.gold)
                {
                    GameManager.instance.playerData.traitspoints += (1 * GameManager.instance.playerData.Wave + GameManager.instance.playerData.level);
                    GameManager.instance.playerData.gold -= traitspointsCost;
                }
                
                break;
            case ButtonType.skill:
                if (NextSkillCost <= GameManager.instance.playerData.bosspoint)
                {
                    int ran = Random.Range(0, item.Length);
                    item[ran].count += 1;
                    GameManager.instance.playerData.bosspoint -= NextSkillCost;

                    temp = PrevSkillCost + NextSkillCost;
                    PrevSkillCost = NextSkillCost;
                    NextSkillCost = temp;
                }
                
                break;
        }
    }
}
