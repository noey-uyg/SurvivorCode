using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{
    public GameObject[] StatData;


    int NextGoldCost = 1;

    Text UpgradeText;
    Text CostText;
    private void Awake()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        UpgradeText = texts[0];
        CostText = texts[1];
    }

    private void LateUpdate()
    {
        UpgradeText.text = string.Format("강화하기");
        CostText.text = string.Format("{0}Gold", NextGoldCost);
    }

    public void OnClick()
    {
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);
        if (NextGoldCost > GameManager.instance.playerData.gold)
            return;

        GameManager.instance.playerData.gold -= NextGoldCost;

        NextGoldCost += 3;



        int ran = Random.Range(0, StatData.Length);
        StatData[ran].GetComponent<Stat>().ClickUpdate();

    }

}
