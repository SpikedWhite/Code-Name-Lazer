using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
   // EnemySpawner EnemySpawner;
   // List<Transform> waypoints;
   // Transform enemyPath;
//
   // int waypointIndex = 0;
   // int b;
//
   // public Transform GetStartingWaypoint()
   // {
   //     return enemyPath.GetChild(0);
   // }
//
   // public List<Transform> GetWaypoints()
   // {
   //     List<Transform> waypoints = new List<Transform>();
   //     foreach (Transform child in enemyPath)
   //     {
   //         waypoints.Add(child);   
   //     }
   //     return waypoints;
   // }
//
   // public void Awake()
   // {
   //     
   //     EnemySpawner = FindObjectOfType<EnemySpawner>();
   //     b = EnemySpawner.currentWaveCount;
   //     
   //     //enemyPath = EnemySpawner.EnemyGroup.pathPrefab;
   //     
   // }
//
   // void Start()
   // {
   //     //enemyPath = EnemySpawner.FollowPath;
   //     waypoints = GetWaypoints();
   //     transform.position = waypoints[waypointIndex].position;
   //    
   // }
//
   // void Update()
   // {
   //     b = EnemySpawner.currentWaveCount;
   //     FollowPath();
   // }
//
   // void FollowPath()
   // {
   //     if(waypointIndex < waypoints.Count)
   //     {
   //         Vector3 targetPosition = waypoints[waypointIndex].position;
   //         float delta = 2; //waveConfig.GetMoveSpeed() * Time.deltaTime;     need to set delta to equal enemy stat move speed instead
   //         transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
   //         if(transform.position == targetPosition)
   //         {
   //             waypointIndex++;
   //             
   //         }
   //     }
   //     else
   //     {
   //         Destroy(gameObject);
   //         //enemySpawn.ReduceEnemyCount();
   //     }
   // }
}
