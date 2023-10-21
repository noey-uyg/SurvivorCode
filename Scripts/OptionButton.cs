using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    RectTransform rect;
    int ClickCount = 0;

    Color bgmcolor;
    Color sfxcolor;

    Text bgm;
    Text sfx;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        Text[] texts = GetComponentsInChildren<Text>();
        bgm = texts[1];
        sfx = texts[2];

        bgmcolor = bgm.color;
        sfxcolor = sfx.color;
    }

    private void FixedUpdate()
    {
        BGMColor();
        SFXColor();
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


    public void Show()
    {
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
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
        GameManager.instance.Resume();
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
