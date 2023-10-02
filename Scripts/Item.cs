using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Weapon weapon;
    public Gear gear;

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

        if (data.itemType == ItemData.ItemType.Range)
        {
            GameObject newWeapon = new GameObject();
            weapon = newWeapon.AddComponent<Weapon>();

            weapon.Init(data);

            level++;
            textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
            textLevel.text = "Lv." + level;
        }
    }

    private void LateUpdate()
    {
        textCount.text = data.count + "°³";
    }

    private void OnEnable()
    {
        textLevel.text = "Lv." + level;
        switch(data.itemType){
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
            case ItemData.ItemType.lightning:
                textDesc.text = string.Format(data.itemDesc,data.damages[level] * 100, data.counts[level]);
                break;
            case ItemData.ItemType.Shoe:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }
        
    }

    public void OnClick()
    {
        if (data.count >= 5)
        {
            int ran = Random.Range(0, 1000);
            Debug.Log(ran);
            if (ran < 10)
            {
                
                switch (data.itemType)
                {
                    case ItemData.ItemType.Melee:
                    case ItemData.ItemType.Range:
                    case ItemData.ItemType.lightning:
                        if (level == 0)
                        {
                            GameObject newWeapon = new GameObject();
                            weapon = newWeapon.AddComponent<Weapon>();

                            weapon.Init(data);
                        }
                        else
                        {
                            float baseDamage = data.baseDamage;
                            float nextDamage = baseDamage;
                            int nextCount = 0;

                            nextDamage += baseDamage * data.damages[level];
                            nextCount += data.counts[level];
                            weapon.LevelUp(nextDamage, nextCount);
                        }
                        level++;
                        textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
                        textLevel.text = "Lv." + level;

                        break;
                }
            }
            data.count -= 5;
        }
        

        if(level == data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
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
