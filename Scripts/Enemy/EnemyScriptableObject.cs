using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]

public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject enemyProjPrefab;
    public GameObject EnemyProjPrefab { get => enemyProjPrefab; private set => enemyProjPrefab = value; }


    [SerializeField]
    float enemyHealthBase;
    public float EnemyHealthBase { get => enemyHealthBase; private set => enemyHealthBase = value; }

    [SerializeField]
    float enemyMoveSpeedBase;
    public float EnemyMoveSpeedBase { get => enemyMoveSpeedBase; private set => enemyMoveSpeedBase = value; }

    

    [SerializeField]
    float enemyFireRateBase;
    public float EnemyFireRateBase { get => enemyFireRateBase; private set => enemyFireRateBase = value; }
    [SerializeField]
    float enemyFireRateChange;
    public float EnemyFireRateChange { get => enemyFireRateChange; private set => enemyFireRateChange = value; }



    [SerializeField]
    int hitScoreBase;
    public int HitScoreBase { get => hitScoreBase; private set => hitScoreBase = value; }
    [SerializeField]
    int killScoreBase;
    public int KillScoreBase { get => killScoreBase; private set => killScoreBase = value; }

    [SerializeField]
    int specialEarnedBase;
    public int SpecialEarnedBase { get => specialEarnedBase; private set => specialEarnedBase = value; }

    
}
