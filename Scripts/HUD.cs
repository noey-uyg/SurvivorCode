using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Wave, Time, Health, gold, bosspoint, traitspoints}
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.playerData.exp;
                float maxExp = GameManager.instance.playerData.nextExp;
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}",GameManager.instance.playerData.level);
                break;
            case InfoType.Wave:
                myText.text = string.Format("{0:F0}wave", GameManager.instance.playerData.Wave);
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.playerData.health;
                float maxHealth = GameManager.instance.playerData.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
            case InfoType.gold:
                myText.text = string.Format("골드 : {0:N0}", GameManager.instance.playerData.gold);
                break;
            case InfoType.bosspoint:
                myText.text = string.Format("보스재화 : {0:N0}", GameManager.instance.playerData.bosspoint);
                break;
            case InfoType.traitspoints:
                myText.text = string.Format("특성포인트 : {0:N0}", GameManager.instance.playerData.traitspoints);
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
