using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public string waveName; //the wave
        public List<EnemyGroup> enemyGroups;
        public int waveQuota; //how many enemies need to be spawned in the wave
        public float spawnInterval; //how long between spawns
        public int spawnCount;  //the number of enemies already spawned
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; //how many of this type need to be spawned
        public int spawnCount; //the number of enemies already spawned
        public GameObject enemyPrefab; 
    }

    public List<Wave> waves;
    public int currentWaveCount;
    
    [Header("Spawn Attributes")]
    public float spawnTimer; //timer used to determine when to spawn the next enemies 
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached;
    public float waveInterval;

    [Header("Spawn Positions")]
    public Transform InitalSpawn;
    
    

    UIUpgrade uiUpgrade;
    
    void Awake()
    {
        uiUpgrade = FindObjectOfType<UIUpgrade>();    
    }


    void Start()
    {
        CalculateWaveQuota();
        StartCoroutine(WaveManager());

    }

    
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator WaveManager()
    {
        yield return new WaitUntil(() => waves[currentWaveCount].spawnCount == waves[currentWaveCount].waveQuota && enemiesAlive == 0);
        
        StartCoroutine(uiUpgrade.DisplayUpgrades());
        yield return new WaitUntil(() => uiUpgrade.UpgradeDone == true);
        yield return new WaitForSeconds(waveInterval);
        if(currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
            StartCoroutine(WaveManager());
            uiUpgrade.hasDisplayed = false;
        }
    }


    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
    }

    void SpawnEnemies()
    {
        if(waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                
                        Instantiate(enemyGroup.enemyPrefab,
                                    InitalSpawn.position,
                                    Quaternion.Euler(0,0,180),
                                    transform);
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                    
                }
            }
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;

    }

    public int GetCurrentWave()
    {
        return currentWaveCount;

    }
}
