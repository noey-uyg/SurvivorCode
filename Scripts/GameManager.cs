using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerData playerData;

    [Header("#Game Object")]
    public PoolManager pool;
    public Player player;
    public GameObject uiResult;
    public GameObject EnemyCleaner;

    [Header("#Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime= 3 * 10f;

    //public int Wave;
    //public int BossSpawnWave;

    //[Header("#Player Stat")]
    //public float baseDamage;
    //public float maxHealth;
    //public float Armor;
    //public float CriPer;
    //public float CriDam;

    //[Header("#Player Info")]
    //public float health;
    //public int level;
    //public int kill;
    //public int exp;
    //public int nextExp;

    //[Header("#Player Characteristic")]
    //public float ChaGoldAmount;
    //public float ChaBossDamage ;
    //public float ChaMonsterDamage;
    //public float ChaMoveSpeed;
    //public float ChaHPDrain;

    //[Header("#Player Characteristic")]
    //public int gold;
    //public int bosspoint;
    //public int traitspoints;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        SavePlayerDataToJson();
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
        LoadPlayerDataToJson();
        playerData.health = playerData.maxHealth;
        isLive = true;
        playerData.level = 1;
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    private void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;
        if(gameTime > maxGameTime)
        {
            gameTime = 0f;
            playerData.Wave += 1;
            playerData.BossSpawnWave += 1;
        }
    }

    public void GetExp()
    {
        playerData.exp++;

        if (playerData.exp == playerData.nextExp) 
        {
            playerData.level++;
            playerData.traitspoints++;
            playerData.exp = 0;
            if (playerData.level % 10 == 0) playerData.nextExp *= 2;
            else playerData.nextExp += 5;

        }
    }

    public void GetGold()
    {
        playerData.gold += (1 + playerData.Wave) + Mathf.FloorToInt((1 + playerData.Wave) * playerData.ChaGoldAmount);
    }

    public void GetBossPoint()
    {
        playerData.bosspoint += 10 + (playerData.kill * 5) + playerData.Wave;
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        playerData.Wave = 1;
        playerData.BossSpawnWave = 1;
        playerData.kill = 0;
        playerData.exp = 0;
        playerData.nextExp = 3;

        isLive = true;
        Time.timeScale = 1;
    }
    
    public void Drain(float hitDamage)
    {
        playerData.health += (hitDamage * playerData.ChaHPDrain);
        if (playerData.health > playerData.maxHealth) playerData.health = playerData.maxHealth;
    }

    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath + "/playerData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataToJson()
    {
        string path = Path.Combine(Application.dataPath + "/playerData.json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }
}
[System.Serializable]
public class PlayerData
{
    public int Wave = 1;
    public int BossSpawnWave = 1;
    public int kill;
    public int exp;
    public int nextExp = 3;

    public float baseDamage = 10f;
    public float maxHealth = 100f;
    public float Armor;
    public float CriPer;
    public float CriDam;

    public float health;
    public int level=1;


    public float ChaGoldAmount;
    public float ChaBossDamage;
    public float ChaMonsterDamage;
    public float ChaMoveSpeed;
    public float ChaHPDrain;

    public int gold;
    public int bosspoint;
    public int traitspoints;
}
