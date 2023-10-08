using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnpoint;
    public SpawnData[] spawnData;

    public int level;
    float timer;
    float summonCycle;
    
    private void Awake()
    {
        spawnpoint = GetComponentsInChildren<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 2);


        //소환주기
        if (timer > spawnData[level].spawnTime - (GameManager.instance.playerData.Wave * 0.0001))
        {
            //Debug.Log(spawnData[level].spawnTime - (GameManager.instance.playerData.Wave * 0.0001));
            timer = 0;
            Spawn();
        }
        if (GameManager.instance.playerData.BossSpawnWave % 10 == 0)
        {
            BossSpawn();
            GameManager.instance.playerData.Wave += 1;
            GameManager.instance.playerData.BossSpawnWave = 1;
        }
    }
    void BossSpawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(4);
        enemy.transform.position = spawnpoint[Random.Range(1, spawnpoint.Length)].position;
        enemy.GetComponent<Boss>().Init(spawnData[2]);
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnpoint[Random.Range(1, spawnpoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }


}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
    public int damage;
}