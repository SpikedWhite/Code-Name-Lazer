using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerShooter playerShooter;
    PlayerStats playerStats;
    [SerializeField] GameObject ShieldPrefab;

    EnemySpawner enemySpawner;

    SpecialTracker specialTracker;

    GameObject[] Enemies;
    EnemyPathing enemypathing;
    EnemyShooter enemyShooter;

    float fireRateTimer;
    float fireRateDuration = 15f;
    
    bool isFrozen = false;
    float freezeTimer;
    float freezeDuration = 10f;

    float specialTimer;
    float specialDuration = 30f;


    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerShooter = FindObjectOfType<PlayerShooter>();
        playerStats = FindObjectOfType<PlayerStats>();

        enemySpawner = FindObjectOfType<EnemySpawner>();

        specialTracker = FindObjectOfType<SpecialTracker>();
    }

    void Start()
    {


    }


    void Update()
    {
        FireRateCheck();
        FreezeCheck();
        SpecialCheck();
    }

    public void FireRateUp()
    {
        if(playerStats.isFireRateUp == true)
        {
            fireRateTimer = 0f;
        }
        else
        {
            playerStats.isFireRateUp = true;
            fireRateTimer = 0f;
        }
    }

    void FireRateCheck()
    {
        if(playerStats.isFireRateUp == true)
        {
            fireRateTimer += Time.deltaTime;
            if(fireRateTimer >= fireRateDuration)
            {
                playerStats.isFireRateUp = false;
            }
        }
    }

    public void Freeze()
    {
        isFrozen = true;
        enemySpawner.enabled = false;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach(GameObject enemy in Enemies)
        {
            enemypathing = enemy.GetComponent<EnemyPathing>();
            enemyShooter = enemy.GetComponent<EnemyShooter>();

            if(enemypathing != null && enemyShooter != null)
            {
                enemypathing.enabled = false;
                enemyShooter.canFire = false;
            }
        }
    }

    public void FreezeCheck()
    {
        if(isFrozen == true)
        {
            freezeTimer += Time.deltaTime;
            Debug.Log(freezeTimer);   
            if(freezeTimer >= freezeDuration)
            {
                Unfreeze();
            }
        }
    }

    public void Unfreeze()
    {
        isFrozen = false;
        freezeTimer = 0f;
        enemySpawner.enabled = true;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach(GameObject enemy in Enemies)
        {
            enemypathing = enemy.GetComponent<EnemyPathing>();
            enemyShooter = enemy.GetComponent<EnemyShooter>();

            if(enemypathing != null)
            {
                enemypathing.enabled = true;
                enemyShooter.canFire = true;
            }
        }
        
    }



    public void Repair()
    {
        playerHealth.RepairPack();
    }

    public void ShieldUp()
    {
        
        if(ShieldPlayer.isShielded){return;}

        GameObject instance = Instantiate(ShieldPrefab, transform.position, transform.rotation); 
        ShieldPlayer.isShielded = true;
    }

    public void Special()
    {
        specialTracker.SpecialActive = true;
        specialTimer = 0f;
        specialTracker.ChangeSpecial(100);
        specialTracker.SpecialCharges = 2;
    }

    void SpecialCheck()
    {
        
        if(specialTracker.SpecialActive)
        {
            specialTimer += Time.deltaTime;
            
            if(specialTimer >= specialDuration)
            {
                
                specialTracker.SpecialActive = false;
                
            }
            else if(specialTracker.SpecialCharges == 0)
            {
                specialTracker.SpecialActive = false;
            }
        }
        
    }
}
