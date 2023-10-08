using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Item : MonoBehaviour
{
    public ItemData data;
    public Weapon weapon;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;
    Text textCount;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;


        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textCount = texts[3];
        textName.text = data.itemName;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject newWeapon = new GameObject();
        weapon = newWeapon.AddComponent<Weapon>();

        for (int i = 0; i < data.level; i++)
        {
            if (i == 0)
            {
                weapon.Init(data);
            }
            else
            {
                float baseDamage = data.baseDamage;
                float nextDamage = baseDamage;
                int nextCount = 0;

                nextDamage += baseDamage * data.damages[i];
                nextCount += data.counts[i];
                weapon.LevelUp(nextDamage, nextCount);
            }
        }
    }

    private void LateUpdate()
    {
        textCount.text = data.count + "°³";
    }

    private void OnEnable()
    {
        textLevel.text = "Lv." + data.level;
        switch(data.itemType){
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
            case ItemData.ItemType.lightning:
                textDesc.text = string.Format(data.itemDesc,data.damages[data.level] * 100, data.counts[data.level]);
                break;

            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }
        
    }

    public void OnClick()
    {

        if (data.count >= 5 && data.level < data.damages.Length-1)
        {
            int ran = Random.Range(0, 1000);
            if (ran < 10)
            {
                switch (data.itemType)
                {
                    case ItemData.ItemType.Melee:
                    case ItemData.ItemType.Range:
                    case ItemData.ItemType.lightning:
                        if (data.level == 0)
                        {
                            weapon.Init(data);
                        }
                        else
                        {
                            float baseDamage = data.baseDamage;
                            float nextDamage = baseDamage;
                            int nextCount = 0;

                            nextDamage += baseDamage * data.damages[data.level];
                            nextCount += data.counts[data.level];
                            weapon.LevelUp(nextDamage, nextCount);
                        }
                        data.level++;
                        textDesc.text = string.Format(data.itemDesc, data.damages[data.level] * 100, data.counts[data.level]);
                        textLevel.text = "Lv." + data.level;

                        break;
                }
            }
            data.count -= 5;
        }
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
