using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyWeaponSO", menuName = "ScriptableObjects/Weapon/Enemy")]

public class EnemyWeaponSO : ScriptableObject
{


    [SerializeField]
    int damageBase;
    public int DamageBase { get => damageBase; private set => damageBase = value; }
    
    [SerializeField]
    float projSpeedBase;
    public float ProjSpeedBase { get => projSpeedBase; private set => projSpeedBase = value; }
    
    [SerializeField]
    float projLifeBase;
    public float ProjLifeBase { get => projLifeBase; private set => projLifeBase = value; }

    [SerializeField]
    int splashDamageBase;
    public int SplashDamageBase { get => splashDamageBase; private set => splashDamageBase = value; }

    [SerializeField]
    float splashRangeBase;
    public float SplashRangeBase { get => splashRangeBase; private set => splashRangeBase = value; }



}
