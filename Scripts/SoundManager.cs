using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    public AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    public AudioSource[] sfxPlayers;
    int channelidx;

    public enum Sfx { Click,EnemyKill,GameOver,PlayerAttack}
    private void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        //BGM 초기화
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        //효과음 초기화
        GameObject sfxObject = new GameObject("BGMPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int i=0; i<channels; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].bypassListenerEffects = true;
            sfxPlayers[i].volume = sfxVolume;
        }
    }

    public void PlayBgm(bool isPlay)
    {
        if (isPlay) bgmPlayer.Play();
        else bgmPlayer.Stop();
    }
    public void PlaySfx(Sfx sfx)
    {
        for(int i = 0; i < channels; i++)
        {
            int loopindex = (i + channelidx) % channels;

            if (sfxPlayers[loopindex].isPlaying) //실행중일땐 끊기지 않고 실행
                continue;

            channelidx = loopindex;

            sfxPlayers[loopindex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopindex].Play();
            break;
        }
        
    }

    public void BgmSetting()
    {
        if (bgmPlayer.mute) bgmPlayer.mute = false;
        else bgmPlayer.mute = true;

    }

    public void SfxSetting()
    {
        for(int i = 0; i < channels; i++)
        {
            if (sfxPlayers[i].mute) sfxPlayers[i].mute = false;
            else sfxPlayers[i].mute = true;
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
