using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{
    public GameObject[] StatData;

    int PrevGoldCost = 0;
    int NextGoldCost = 1;
    int temp = 0;

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
        if (NextGoldCost > GameManager.instance.gold)
            return;

        GameManager.instance.gold -= NextGoldCost;

        temp = PrevGoldCost + NextGoldCost;
        PrevGoldCost = NextGoldCost;
        NextGoldCost = temp;

        
        int ran = Random.Range(0, StatData.Length);
        StatData[ran].GetComponent<Stat>().ClickUpdate();
    }

}
