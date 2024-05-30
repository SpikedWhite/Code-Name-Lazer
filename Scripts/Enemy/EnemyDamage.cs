using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] EnemyWeaponSO weaponStats;
    
    AudioPlayer audioPlayer;
    

    Rigidbody2D RB1;

    float currentProjLife;
    [SerializeField] bool bomb;

    void Awake()
    {
        
        audioPlayer = FindObjectOfType<AudioPlayer>();
        
        RB1 = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        RB1.velocity = transform.up * weaponStats.ProjSpeedBase;

        currentProjLife = weaponStats.ProjLifeBase;
        

        
        Destroy(gameObject, currentProjLife);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(GetDamage()); 
            audioPlayer.PlayDamageClip();
            playerHealth.PlayHitEffect();
            Hit();
        }
    }

    public float GetDamage()
    {
        return weaponStats.DamageBase;
        
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    

    
}
