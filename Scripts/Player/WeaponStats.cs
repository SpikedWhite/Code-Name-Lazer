using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    public PlayerWeaponSO bulletData;
    public PlayerWeaponSO bombData;
    
    
    
    [HideInInspector]
    public int bulletDamage;
    [HideInInspector]
    public float bulletProjSpeed;
    [HideInInspector]
    public float bulletProjLife;


    [HideInInspector]
    public int bombDamage;
    [HideInInspector]
    public float bombProjSpeed;
    [HideInInspector]
    public float bombProjLife;
    [HideInInspector]
    public int SplashDamage;
    [HideInInspector]
    public float SplashRange;


    [HideInInspector]
    public int DamageMod;
    [HideInInspector]
    public float ProjSpeedMod;
    [HideInInspector]
    public int SplashDamageMod;
    [HideInInspector]
    public float SplashRangeMod;
    

    void Awake()
    {       
        DamageMod = 0;
        ProjSpeedMod = 1f;
        SplashDamageMod = 0;
        SplashRangeMod = 1f;


        bulletDamage = bulletData.DamageBase;
        bulletProjSpeed = bulletData.ProjSpeedBase;
        
        bulletProjLife =  bulletData.ProjLifeBase;
        


        bombDamage = bombData.DamageBase;
        bombProjSpeed = bombData.ProjSpeedBase;
        
        bombProjLife = bombData.ProjLifeBase;
        
        SplashDamage = bombData.SplashDamageBase;
        SplashRange = bombData.SplashRangeBase;
    }

    public int GetCurrentBulletDamage()
    {
        return bulletDamage + DamageMod;
    }

    public float GetBulletProjSpeed()
    {
        return bulletProjSpeed * ProjSpeedMod;
    }




    public int GetCurrentBombDamage()
    {
        return bombDamage + DamageMod;
    }

    public float GetBombProjSpeed()
    {
        return bombProjSpeed * ProjSpeedMod;
    }

    public int GetSplashDamage()
    {
        return SplashDamage + SplashDamageMod;
    }

    public float GetSplashRange()
    {
        return SplashRange + SplashDamageMod; 
    }
}
