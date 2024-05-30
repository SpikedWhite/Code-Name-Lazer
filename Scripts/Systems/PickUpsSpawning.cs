using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsSpawning : MonoBehaviour
{
    [SerializeField] List<GameObject> PossiblePickups;
    
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingTop;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 RandomSpawn;

    private bool CanSpawnPowerUp = true;


    private int PP;

    void start()
    {
        InitBounds();
        
    }

    void Update()
    {
        StartCoroutine(ManagePowerUpSpawning());
        PowerUpMovement();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    public GameObject GetPowerUp(int index)
    {
        return PossiblePickups[index];
    }

    public int GetPowerUpCount()
    {
        return PossiblePickups.Count;
    }

    public int GetRandomPowerUp()
    {
        int PP = Random.Range(0, GetPowerUpCount());
        return PP;
    }

    public IEnumerator ManagePowerUpSpawning()
    {
        if(CanSpawnPowerUp == true)
        {
            Vector2 NewRandomSpawn = new Vector2();
            NewRandomSpawn.x = Random.Range(-5.5f, 5.5f);
            NewRandomSpawn.y = Random.Range(-9.5f, 9.5f);
            
            transform.position = NewRandomSpawn;
            Instantiate(GetPowerUp(GetRandomPowerUp()), transform.position, Quaternion.Euler(0,0,0), transform);
            CanSpawnPowerUp = false;
            yield return new WaitUntil(() => CanSpawnPowerUp == true);
        }
    }

    void PowerUpMovement()
    {
        Vector2 movePos = new Vector2();
        movePos.x = 0;
        movePos.y = 0;
    }
}