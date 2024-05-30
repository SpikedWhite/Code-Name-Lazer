using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PowerUpDrop", menuName = "ScriptableObjects/PowerUp")]

public class PowerUpSO : ScriptableObject
{
    public GameObject powerObject;

    public string powerName;
    
    public int powerDropChance;

    

    public PowerUpSO(GameObject powerObject, string powerName, int powerDropChance)
    {
        this.powerObject = powerObject;
        this.powerName = powerName;
        this.powerDropChance = powerDropChance;
    }
}
