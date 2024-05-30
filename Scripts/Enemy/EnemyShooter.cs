using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    EnemyStats enemyStats;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    float CurrentFireRate;
    float FireRateChange;
    
    float CurrentProjSpeed;
    float CurrentProjLife;

    float CurrentDamage;

    
    

    bool isFiring = true;
    public bool canFire = false;

    void Awake()
    {
        enemyStats = FindObjectOfType<EnemyStats>();
        audioPlayer = FindObjectOfType<AudioPlayer>();

        
    }

    void Start()
    {
        CurrentFireRate = enemyStats.enemyFireRate;
        FireRateChange = enemyStats.enemyFireChange;

        
    }

    
    void Update()
    {
        Fire();

    }

    void Fire()
    {
            if (isFiring && firingCoroutine == null)
            {
                firingCoroutine = StartCoroutine(FireContinuously());
            }
            else if(!isFiring && firingCoroutine != null)
            {
                StopCoroutine(firingCoroutine);
                firingCoroutine = null;
            }
    }

    IEnumerator FireContinuously()
    {
        
            while(true)
            {
            
            if(canFire)
            {
                GameObject instance = Instantiate(enemyStats.enemyProjPrefab, transform.position, transform.rotation);
                audioPlayer.PlayShootingClip();
                
            }
            float timeToNextProjectile = Random.Range(CurrentFireRate - FireRateChange, CurrentFireRate + FireRateChange);
            //timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, firingRateMin, float.MaxValue);
            
            yield return new WaitForSeconds(timeToNextProjectile);
            
            }
        
    }
    
}
