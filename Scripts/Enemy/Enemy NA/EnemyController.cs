using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public EnemyScriptableObject enemyData;

    [SerializeField] ParticleSystem hitEnemyEffect;


    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    EnemySpawner enemySpawner;

    float currentHealth;
    float currentMoveSpeed;
    float currentDamage;
    float currentProjectileSpeed;
    float currentFireRate;


    //This section is related to enemy health, damage taking, and special effects related to
    //--------------------------------------------------

    //void Awake()
    //{
    //    audioPlayer = FindObjectOfType<AudioPlayer>();
    //    scoreKeeper = FindObjectOfType<ScoreKeeper>();
    //    enemySpawner = FindObjectOfType<EnemySpawner>();
//
    //    currentHealth = enemyData.MaxHealth;
    //    currentMoveSpeed = enemyData.MoveSpeed;
    //    //currentDamage = enemyData.Damage;
    //    //currentProjectileSpeed = enemyData.ProjectileSpeed;
    //    currentFireRate = enemyData.FireRate;
//
    //}
   //
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    PlayerDamage playerDamage = other.GetComponent<PlayerDamage>();
//
    //    if(playerDamage != null)
    //    {
    //        TakeDamage(playerDamage.GetDamage()); 
    //        audioPlayer.PlayDamageClip();
    //        PlayHitEffect();
    //        playerDamage.Hit();
    //    }
    //}
//
    //void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    if(currentHealth <= 0)
    //    {
    //        Killed();
    //    }
    //}
//
    //void Killed()
    //{
    //    enemySpawner.OnEnemyKilled();
    //    scoreKeeper.ChangeScore(enemyData.KillScore);
    //    Destroy(gameObject);
    //}
//
    //void PlayHitEffect()
    //{
    //    if(hitEnemyEffect != null)
    //    {
    //        ParticleSystem instance = Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
    //        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    //    }
    //    
    //}
//
    ////---------------------------------------
//
    ////Below is where all pathfinding related code is handled
//
//
    //List<Transform> waypoints;
    //int waypointIndex = 0;
//
    //void Start()
    //{
    //    waypoints = GetWaypoints();
    //    transform.position = waypoints[waypointIndex].position;
    //}
//
    //void Update()
    //{
    //    FollowPath();
    //}
//
    //public List<Transform> GetWaypoints()
    //{
    //    List<Transform> waypoints = new List<Transform>();
    //    foreach (Transform child in enemyData.PathPrefab)
    //    {
    //        waypoints.Add(child);   
    //    }
    //    return waypoints;
    //}
//
    //public Transform GetStartingWaypoint()
    //{
    //    return enemyData.PathPrefab.GetChild(0);
    //}
//
    //void FollowPath()
    //{
    //    if(waypointIndex < waypoints.Count)
    //    {
    //        Vector3 targetPosition = waypoints[waypointIndex].position;
    //        float delta = enemyData.MoveSpeed * Time.deltaTime;
    //        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
    //        if(transform.position == targetPosition)
    //        {
    //            waypointIndex++;
    //        }
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //        enemySpawner.OnEnemyKilled();
    //    }
    //}
}//
//