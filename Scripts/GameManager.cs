using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("#Game Object")]
    public PoolManager pool;
    public Player player;
    public GameObject uiResult;
    public GameObject EnemyCleaner;

    [Header("#Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime= 3 * 10f;
    public int Wave = 1;
    //public float summonCycle = 2f;

    [Header("#Player Stat")]
    public float baseDamage = 10f;
    public float maxHealth = 100f;
    public float Armor;
    public float CriPer;
    public float CriDam;

    [Header("#Player Info")]
    public float health;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

    [Header("#Player Characteristic")]
    public float ChaGoldAmount;
    public float ChaBossDamage ;
    public float ChaMonsterDamage;
    public float ChaMoveSpeed;
    public float ChaHPDrain;

    [Header("#Player Characteristic")]
    public int gold;
    public int bosspoint;
    public int traitspoints;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        isLive = false;
        EnemyCleaner.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        uiResult.SetActive(true);

        Stop();
    }

    private void Start()
    {
        health = maxHealth;
        isLive = true;
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;
        if(gameTime > maxGameTime)
        {
            gameTime = 0f;
            Wave += 1;
            //summonCycle -= 0.05f;
            //if (summonCycle < 0.1f)
            //{
            //    summonCycle = 0.1f;
            //}
        }
    }

    public void GetExp()
    {
        exp++;

        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)]) 
        {
            level++;
            traitspoints++;
            exp = 0;
        }
    }

    public void GetGold()
    {
        gold += (1 + Wave) + Mathf.FloorToInt((1 + Wave) * ChaGoldAmount);
    }
    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
