using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] GameObject ShieldPrefab;

    PlayerHealth playerhealth;
    PlayerShooter playershooter;
    
    CogsCounter cogsCounter;
    
    EnemySpawner enemySpawner;
    
    GameObject[] Enemies;
    EnemyPathing enemypathing;
    EnemyShooter enemyShooter;

    PickUpManager pickupManager;

    [SerializeField] float fallSpeed; 

    

    void Awake()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
        playershooter = FindObjectOfType<PlayerShooter>();

        cogsCounter = FindObjectOfType<CogsCounter>();

        enemySpawner = FindObjectOfType<EnemySpawner>();

        pickupManager = FindObjectOfType<PickUpManager>();

        Rigidbody2D rbPowerUp = GetComponent<Rigidbody2D>();
        rbPowerUp.velocity = transform.up * -fallSpeed;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet")
        {
            return;
        }

        if(tag == "FireRate+")
        {
            Destroy(gameObject);
            Debug.Log("Fire Rate is increased");
            pickupManager.FireRateUp();
        }

        if(tag == "Freeze+")
        {
            Destroy(gameObject);
            Debug.Log("Enemies are frozen");
            pickupManager.Freeze();
        }

        if(tag == "Repair+")
        {
            float H = playerhealth.GetHealth();
            if(H < playerhealth.currentMaxHealth)
            {
            Destroy(gameObject);
            Debug.Log("Repaired");
            pickupManager.Repair();
            }        
        }

        if(tag == "Shield+")
        {
            if(ShieldPlayer.isShielded){return;}
            Destroy(gameObject);
            Debug.Log("You are now shielded");
            pickupManager.ShieldUp();
        }

        if(tag == "Special+")
        {
            Destroy(gameObject);
            Debug.Log("Special activated");
            pickupManager.Special();
        }

        

        if(tag == "Scrap")
        {
            LootStats lootStats = GetComponent<LootStats>();
            int coins = Random.Range(1, 6);
            cogsCounter.ChangeCogs(coins);
            Destroy(gameObject);
            
        }
    }

    
}
