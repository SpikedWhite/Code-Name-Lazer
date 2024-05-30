using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    [HideInInspector]
    public GameObject enemyProjPrefab;

    [HideInInspector]
    public float enemyHealth;
    [HideInInspector]
    public float enemyMoveSpeed;
    
    
    [HideInInspector]
    public float enemyFireRate;
    [HideInInspector]
    public float enemyFireChange;


    [HideInInspector]
    public int hitScore;
    [HideInInspector]
    public int killScore;

    [HideInInspector]
    public int specialEarned;

    void Awake()
    {

        enemyProjPrefab = enemyData.EnemyProjPrefab;

        enemyHealth = enemyData.EnemyHealthBase;
        enemyMoveSpeed = enemyData.EnemyMoveSpeedBase;


        enemyFireRate = enemyData.EnemyFireRateBase;
        enemyFireChange = enemyData.EnemyFireRateChange;

       
        hitScore = enemyData.HitScoreBase;
        killScore = enemyData.KillScoreBase;

        specialEarned = enemyData.SpecialEarnedBase;

    }
}
