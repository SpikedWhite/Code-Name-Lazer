using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    WeaponStats weaponStats;
    GameObject self;
    GameObject player;
    AudioPlayer audioPlayer;
    Rigidbody2D RB1;

    float currentBulletProjSpeed;

    float currentBulletProjLife;
    float currentBombProjLife;

    float currentBombProjSpeed;
    float currentSplashDamage;
    float currentSplashRange;


    

    [SerializeField] bool bomb;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        player = GameObject.Find("Lazer (Player)");

        weaponStats = player.GetComponent<WeaponStats>();
        RB1 = GetComponent<Rigidbody2D>();
        
        self = this.gameObject;
        
    }

    void Start()
    {
        if(bomb)
        {

            currentBombProjSpeed = weaponStats.GetBombProjSpeed();
            currentBombProjLife = weaponStats.bombProjLife;
            currentSplashDamage = weaponStats.GetSplashDamage();
            currentSplashRange = weaponStats.GetSplashRange();
            RB1.velocity = transform.up * currentBombProjSpeed;
        }
        
        else
        {
            currentBulletProjSpeed = weaponStats.GetBulletProjSpeed();
            currentBulletProjLife = weaponStats.bulletProjLife;
            
            RB1.velocity = transform.up * currentBulletProjSpeed;

        }
    }

    void Update()
    {

        if(bomb)
        {
        currentBombProjSpeed = weaponStats.GetBombProjSpeed();
        currentSplashDamage = weaponStats.GetSplashDamage();
        currentSplashRange = weaponStats.GetSplashRange();

        Destroy(gameObject, currentBombProjLife);
        }

        else
        {
        currentBulletProjSpeed = weaponStats.GetBulletProjSpeed();

        Destroy(gameObject, currentBulletProjLife);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            if(!bomb)
            {

                enemyHealth.TakeDamage(GetBulletDamage()); 
                audioPlayer.PlayDamageClip();
                enemyHealth.PlayHitEffect();
                Hit();

            }
            else
            {
                enemyHealth.TakeDamage(GetBombDamage());
                audioPlayer.PlayDamageClip();
                enemyHealth.PlayHitEffect();
                StartCoroutine(BombLife());
                Hit();
            }

        

        }
    }
    
    public int GetBulletDamage()
    {
        return weaponStats.GetCurrentBulletDamage();
    }

    public int GetBombDamage()
    {
        return weaponStats.GetCurrentBombDamage();
    }

    public void Hit()
    {
        Destroy(self);
    }

    public IEnumerator BombLife()
    {
        
        if(currentSplashRange > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, currentSplashRange);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<EnemyHealth>();
                if(enemy)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(currentSplashRange, 0, distance);
                    int roundDamage = Mathf.RoundToInt(damagePercent * GetBombDamage());
                    enemy.TakeDamage(roundDamage);
                }
            }
        }
        yield return new WaitForSeconds(currentBombProjLife);

        Destroy(self);
    }

    
}
