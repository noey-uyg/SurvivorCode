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
    public float saveTime;
    public float maxSaveTime = 1.5f * 10f;
    public bool isX2;

    private void Awake()
    {
        LoadPlayerDataToJson();
        instance = this;
    }

    public void Time_2x()
    {
        if (isX2)
        {
            isX2 = false;
            Time.timeScale = 1f;
        }
        else
        {
            isX2 = true;
            Time.timeScale = 2f;
        }
    }

    public void GameOver()
    {
        GameOverLossGold();
        SavePlayerDataToJson();
        StartCoroutine(GameOverRoutine());
    }

    void GameOverLossGold()
    {
        playerData.level = 1;
        playerData.Wave = 1;
        playerData.BossSpawnWave = 1;
        playerData.kill = 0;
        playerData.exp = 0;
        playerData.nextExp = 3;
        playerData.gold = (int)(playerData.gold *0.3f);
    }

    IEnumerator GameOverRoutine()
    {
        isLive = false;
        EnemyCleaner.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        uiResult.SetActive(true);

        Stop();
        SoundManager.instance.PlayBgm(false);
        SoundManager.instance.PlaySfx(SoundManager.Sfx.GameOver);
    }

    private void Start()
    {
        
        playerData.health = playerData.maxHealth;
        isLive = true;
        SoundManager.instance.PlayBgm(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
        SoundManager.instance.PlayBgm(true);
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);
    }

    private void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;
        saveTime += Time.deltaTime;

        if(gameTime > maxGameTime)
        {
            gameTime = 0f;
            playerData.Wave += 1;
            playerData.BossSpawnWave += 1;
        }
        
        if(saveTime > maxSaveTime)
        {
            saveTime = 0f;
            SavePlayerDataToJson();
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
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isLive = true;
        if (isX2)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
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
        //string path = Path.Combine(Application.dataPath + "/playerData.json");
        string path = Path.Combine(Application.persistentDataPath + "/playerData.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("저장완료");
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataToJson()
    {
        //string path = Path.Combine(Application.dataPath + "/playerData.json");
        string path = Path.Combine(Application.persistentDataPath + "/playerData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            Debug.Log("불러오기 완료");
        }
        else
        {
            playerData = new PlayerData();
            Debug.Log("파일생성 완료");
        }
        
    }
}

public class PlayerData
{
    public int Wave = 1;
    public int BossSpawnWave = 1;
    public int kill;
    public int exp;
    public int nextExp = 3;

    public float baseDamage = 10f;
    public int baseDamageLevel;
    public float maxHealth = 100f;
    public int maxHealthLevel;
    public float Armor;
    public int ArmorLevel;
    public float CriPer;
    public int CriPerLevel;
    public float CriDam;
    public int CriDamLevel;

    public float health;
    public int level=1;

    public float ChaGoldAmount;
    public int ChaGoldAmountLevel;
    public float ChaBossDamage;
    public int ChaBossDamageLevel;
    public float ChaMonsterDamage;
    public int ChaMonsterDamageLevel;
    public float ChaMoveSpeed;
    public int ChaMoveSpeedLevel;
    public float ChaHPDrain;
    public int ChaHPDrainLevel;

    public int gold;
    public int bosspoint;
    public int traitspoints;
}