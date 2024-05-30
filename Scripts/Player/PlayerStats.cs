using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerStats : MonoBehaviour
{

    public PlayerScriptableObject PlayerData;

    

    [HideInInspector]
    public ParticleSystem hitEffect;
    [HideInInspector]
    public ParticleSystem playerNukeEffect;
    
    [HideInInspector]
    public GameObject ProjPrefab;
    [HideInInspector]
    public GameObject BombPrefab;

    [HideInInspector]
    public int Health;
    
    [HideInInspector]
    public float MoveSpeed;

    [HideInInspector]
    public int IFrames;

    [HideInInspector]
    public float PrimaryFireRate;
    [HideInInspector]
    public float BombFireRate;

    [HideInInspector]
    public float DashDuration;


    [HideInInspector]
    public int HealthMod;
    [HideInInspector]
    public float MoveSpeedMod;
    [HideInInspector]
    public float FireRateMod;
    [HideInInspector]
    public float DashMod;


    [HideInInspector]
    public bool isFireRateUp = false;
    [HideInInspector]
    public float FireRatePowerUp;
    
    
    void Awake()
    {
        
        HealthMod = 0;
        MoveSpeedMod = 1f;
        FireRateMod = 0f;
        DashMod = 0f;
        FireRatePowerUp = .5f;


        playerNukeEffect = PlayerData.PlayerNukeEffect;
        hitEffect = PlayerData.HitEffect;

        ProjPrefab = PlayerData.ProjectilePrefab;
        BombPrefab = PlayerData.BombPrefab;
    
        Health = PlayerData.HealthBase;
        
        MoveSpeed = PlayerData.MoveSpeedBase;
        
        IFrames = PlayerData.IFramesDurBase;
        
        PrimaryFireRate = PlayerData.P_FireRateBase;
        BombFireRate = PlayerData.B_FireRateBase;

        DashDuration = PlayerData.DashDurationBase;
    }


    public int GetMaxHealth()
    {
        return Health + HealthMod;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed * MoveSpeedMod;
    }

    public float GetPrimaryFireRate()
    {
        if(!isFireRateUp)
        {
            return PrimaryFireRate - FireRateMod;
        }
        else
        {
            return PrimaryFireRate - FireRateMod - FireRatePowerUp;
        }
    }
    public float GetBombFireRate()
    {
        if(!isFireRateUp)
        {
            return BombFireRate - FireRateMod;
        }
        else
        {
            return BombFireRate - FireRateMod - FireRatePowerUp;
        }
    }

    public float GetDashDuration()
    {
        return DashDuration + DashMod;
    }
}
