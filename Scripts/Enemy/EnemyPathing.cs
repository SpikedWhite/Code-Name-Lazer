using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    
    EnemyStats enemyStats;

    EnemySpawner enemySpawner;

    EnemyShooter enemyShooter;

    float currentMoveSpeed;

    [SerializeField] List<Transform> PathPreFabs;

    Transform activePath;

    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {

        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemyStats = GetComponent<EnemyStats>();
        enemyShooter = GetComponent<EnemyShooter>();
        GetPathPreFab();
        
    }

    void Start()
    {
        
        waypoints = GetWaypoints();
        //transform.position = waypoints[waypointIndex].position;
        currentMoveSpeed = enemyStats.enemyMoveSpeed;
    }

    void Update()
    {
        FollowPath();
        if(waypointIndex >= 1)
        {
            enemyShooter.canFire = true;
        }
    }

    public Transform GetPathPreFab()
    {
        activePath = PathPreFabs[Random.Range(0, PathPreFabs.Count)];
        return activePath;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        //if(activePath != null)
        
        foreach (Transform child in activePath)
        {
            waypoints.Add(child);   
        }
        return waypoints;
    }

    public Transform GetStartingWaypoint()
    {
        return activePath.GetChild(0);
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = currentMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            enemySpawner.OnEnemyKilled();
        }
    }

}
