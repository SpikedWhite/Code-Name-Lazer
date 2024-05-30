using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LootDrop", menuName = "ScriptableObjects/Loot")]

public class LootSO : ScriptableObject
{
    [SerializeField]
    int dropChance;
    public int DropChance { get => dropChance; private set => dropChance = value; }

    [SerializeField]
    int minRange;
    public int MinRange { get => minRange; private set => minRange = value; }

    [SerializeField]
    int maxRange;
    public int MaxRange { get => maxRange; private set => maxRange = value; }
    
    //[SerializeField]
    public int scrapAmount;
    //public int ScrapAmount { get => scrapAmount; private set => scrapAmount = value; }


}
