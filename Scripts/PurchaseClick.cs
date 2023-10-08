using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseClick: MonoBehaviour
{
    public enum ButtonType {characteristic, stat, skill, purchase }
    public ButtonType buttonType;

    RectTransform rect;
    Item[] items;
    Characteristic[] characteristics;
    Stat[] stats;
    
    int ClickCount = 0;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
        characteristics = GetComponentsInChildren<Characteristic>(true);
        stats = GetComponentsInChildren<Stat>(true);

        foreach (Stat stat in stats)
        {
            stat.gameObject.SetActive(false);
        }
    }
    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;

        if (ClickCount != 0)
        {
            Hide();
        }
        else
        {
            ClickCount++;
        }
        
    }

    public void Hide()
    {
        ClickCount = 0;
        rect.localScale = Vector3.zero;
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }

    void Next()
    {
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);
        switch (buttonType)
        {
            
            case ButtonType.skill:
                foreach (Item item in items)
                {
                    item.gameObject.SetActive(true);
                }
                break;
            case ButtonType.purchase:
                foreach (Item item in items)
                {
                    item.gameObject.SetActive(true);
                }
                break;
            case ButtonType.characteristic:
                foreach (Characteristic characteristic in characteristics)
                {
                    characteristic.gameObject.SetActive(true);
                }
                break;
            case ButtonType.stat:
                foreach (Stat stat in stats)
                {
                    stat.gameObject.SetActive(true);
                }
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
