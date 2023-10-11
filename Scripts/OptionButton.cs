using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    RectTransform rect;
    int ClickCount = 0;

    Color speedButtoncolor;
    Color bgmcolor;
    Color sfxcolor;

    Image speedButton;
    Text bgm;
    Text sfx;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        speedButton = GetComponentsInChildren<Image>()[1];


        Text[] texts = GetComponentsInChildren<Text>();
        bgm = texts[1];
        sfx = texts[2];

        speedButtoncolor = speedButton.color;
        bgmcolor = bgm.color;
        sfxcolor = sfx.color;
    }

    private void FixedUpdate()
    {
        BGMColor();
        SFXColor();
        X2Color();
    }

    void BGMColor()
    {
        if (SoundManager.instance.bgmPlayer.mute)
        {
            bgmcolor.a = 0.5f;
            bgm.color = bgmcolor;
        }
        else
        {
            bgmcolor.a = 1f;
            bgm.color = bgmcolor;
        }
    }

    void SFXColor()
    {
        if (SoundManager.instance.sfxPlayers[0].mute)
        {
            sfxcolor.a = 0.5f;
            sfx.color = sfxcolor;
        }
        else
        {
            sfxcolor.a = 1f;
            sfx.color = sfxcolor;
        }
    }

    void X2Color()
    {
        
        if (!GameManager.instance.isX2)
        {
            speedButtoncolor.a = 0.5f;
            speedButton.color = speedButtoncolor;
        }
        else
        {
            speedButtoncolor.a = 1f;
            speedButton.color = speedButtoncolor;
        }
    }

    public void Show()
    {
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
