using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootTable : MonoBehaviour
{
    //LootStats lootNumbers;
    //public GameObject droppedItemPrefab;
    

    public List<GameObject> LootTable = new List<GameObject>();

    GameObject GetDroppedLoot()
    {
        //if(LootTable.Count == 0) return null;
        int ranNum = Random.Range(1, 101);
        List<GameObject> possibleItems = new List<GameObject>();
        
        foreach(GameObject item in LootTable)
        {
            LootStats lootstats = item.GetComponent<LootStats>();
            if(lootstats != null)
            {
                if(ranNum > lootstats.LootData.MinRange && ranNum < lootstats.LootData.MaxRange)
                {
                
                    possibleItems.Add(item);
                
                }
            }
        }
        if(possibleItems.Count > 0)
        {
            GameObject droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }

    public void SpawnLoot(Vector3 spawnPosition)
    {

        GameObject droppedItem = GetDroppedLoot();
        //LootStats lootstats = droppedItem.GetComponent<LootStats>();
        //Rigidbody2D lootRB2D = droppedItem.GetComponent<Rigidbody2D>();

        Vector3 RandomSpawn = spawnPosition + (Vector3)Random.insideUnitCircle;

        if(droppedItem != null)
        {
            Instantiate(droppedItem, RandomSpawn, Quaternion.identity);
        
        }
    }






    public List<GameObject> PowerUpList = new List<GameObject>();
    
    GameObject GetPowerUp()
    {
        int rndPWR = Random.Range(1, PowerUpList.Count);
        return PowerUpList[rndPWR];
    }

    public void SpawnPower(Vector3 spawnPosition)
    {
        GameObject spawnedPower = GetPowerUp();

        Vector3 RandomSpawn = spawnPosition + (Vector3)Random.insideUnitCircle;

        if(spawnedPower != null)
        {
            Instantiate(spawnedPower, RandomSpawn, Quaternion.identity);

        }

    }


}
