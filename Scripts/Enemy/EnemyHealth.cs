using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //EnemyScriptableObject enemyData;

    [SerializeField] ParticleSystem hitEnemyEffect;

    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    SpecialTracker specialTracker;

    EnemySpawner enemySpawner;

    EnemyStats enemyStats;

    float currentHealth;
    

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        specialTracker = FindObjectOfType<SpecialTracker>();


        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemyStats = GetComponent<EnemyStats>();


    }
   
    void Start()
    {
        currentHealth = enemyStats.enemyHealth;
    }    

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        scoreKeeper.ChangeScore(enemyStats.hitScore);
        if(currentHealth <= 0)
        {
            Killed();
        }
    }

    void Killed()
    {
        enemySpawner.OnEnemyKilled();
        scoreKeeper.ChangeScore(enemyStats.killScore);
        specialTracker.ChangeSpecial(enemyStats.specialEarned);

        int PowerChance = Random.Range(1, 11);
        if(PowerChance == 1)
        {
        GetComponent<EnemyLootTable>().SpawnPower(transform.position);
        }

        GetComponent<EnemyLootTable>().SpawnLoot(transform.position);

        Destroy(gameObject);
    }

    public void PlayHitEffect()
    {
        if(hitEnemyEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
        
    }
    
    
}
