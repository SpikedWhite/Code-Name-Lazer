using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    
    PlayerStats playerStats;

    Coroutine firingCoroutine;
    
    
    AudioPlayer audioPlayer;

    
    float currentPrimaryFireRate;
    float currentBombFireRate;


    GameObject currentProjPrefab;
    GameObject currentBombPrefab;


    [HideInInspector] public bool isFiring;

    public static bool isBombReady = true;
    

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        playerStats = GetComponent<PlayerStats>();
        
    }

    void Start()
    {
        currentProjPrefab = playerStats.ProjPrefab;
        currentBombPrefab = playerStats.BombPrefab;

        currentPrimaryFireRate = playerStats.PrimaryFireRate;
        currentBombFireRate = playerStats.BombFireRate;
    }

    
    void Update()
    {
        currentPrimaryFireRate = playerStats.GetPrimaryFireRate();
        currentBombFireRate = playerStats.GetBombFireRate();

        if(UIUpgrade.isPaused){return;}
        if(UIUpgrade.isUpgrading){return;}
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
            GameObject instance = Instantiate(currentProjPrefab, transform.position, transform.rotation);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(currentPrimaryFireRate);
        }
        
    }


    public IEnumerator Bananabomb()
    {
        
        if(isBombReady == true)
        {
            GameObject Secondary = Instantiate(currentBombPrefab, transform.position, transform.rotation);
            
            isBombReady = false;
            
            
            yield return new WaitForSeconds(currentBombFireRate);
            isBombReady = true;
            
            
        }
    }

}
