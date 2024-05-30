using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 
    PlayerStats playerStats;
    ParticleSystem playerHitEffect;

    
    CameraShake cameraShake;
    bool applyCameraShake = true;

    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    

    float currentHealth;
    [HideInInspector]
    public float currentMaxHealth;

    float currentIFramesDuration;
    float IFramesTimer;
    bool isInvincible;

    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        
        
        
        
    }

    void Start()
    {
        currentHealth = playerStats.Health;
        currentMaxHealth = playerStats.Health;

        playerHitEffect = playerStats.hitEffect;

        currentIFramesDuration = playerStats.IFrames;
    
    
    
    
    }

    void Update()
    {
        currentMaxHealth = playerStats.GetMaxHealth();
        IFrames();


    }

    void IFrames()
    {
        if(IFramesTimer > 0)
        {
            IFramesTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyDamage enemyDamage = other.GetComponent<EnemyDamage>();

        if(enemyDamage != null)
        {
            if(!isInvincible)
            {
                TakeDamage(enemyDamage.GetDamage()); //Should be here.
                audioPlayer.PlayDamageClip();
                PlayHitEffect();
                ShakeCamera();
                enemyDamage.Hit();
            }
            
        }

        //TakeDamage should not be here.
        //TakeDamage();
    }

    //How i chose to write the method for taking damage.
    // void TakeDamage()
    // {
    //     enemyDamage enemyDamage = FindObjectOfType<enemyDamage>();
    //     int H = enemyDamage.GetDamage();
    //     HealthBase -= H;
    //
    //     if(HealthBase <= 0)
    //     {
    //         Destroy(gameObject);
    //     }
    //     
    //     Debug.Log("Health is " + HealthBase);
    // }

    //A better way for it to be written.


    public void TakeDamage(float damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;

            IFramesTimer = currentIFramesDuration;
            isInvincible = true;
            
            if(currentHealth <= 0)
            {
                Die();
            }
        }
        
        
    }

    public void RepairPack()
    {
        if(currentHealth < currentMaxHealth)
        {
            currentHealth += 10;
        }
    }

    void Die()
    {

        levelManager.LoadGameOver();
        
        Destroy(gameObject);
    }

    

    public void PlayHitEffect()
    {
        
        if(playerHitEffect != null)
        {
            ParticleSystem instance = Instantiate(playerHitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
        
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
            
        }
    }
}
