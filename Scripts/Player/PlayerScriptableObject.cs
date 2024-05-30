using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="PlayerScriptableObject", menuName = "ScriptableObjects/Player")]

public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField]
    ParticleSystem hitEffect;
    public ParticleSystem HitEffect { get => hitEffect; private set => hitEffect = value; }
    [SerializeField]
    ParticleSystem playerNukeEffect;
    public ParticleSystem PlayerNukeEffect { get => playerNukeEffect; private set => playerNukeEffect = value; }


    [SerializeField]
    GameObject projectilePrefab;
    public GameObject ProjectilePrefab { get => projectilePrefab; private set => projectilePrefab = value; }
    
    [SerializeField]
    GameObject bombPrefab;
    public GameObject BombPrefab { get => bombPrefab; private set => bombPrefab = value; }
    
    
    
    
    [SerializeField]
    int healthBase;
    public int HealthBase { get => healthBase; private set => healthBase = value; }
    
    [SerializeField]
    float moveSpeedBase;
    public float MoveSpeedBase { get => moveSpeedBase; private set => moveSpeedBase = value; }
    
    
    [SerializeField]
    int iFramesDurBase;
    public int IFramesDurBase { get => iFramesDurBase; private set => iFramesDurBase = value; }
    
    [SerializeField]
    float p_fireRateBase;
    public float P_FireRateBase { get => p_fireRateBase; private set => p_fireRateBase = value; }
    
    [SerializeField]
    float b_fireRateBase;
    public float B_FireRateBase { get => b_fireRateBase; private set => b_fireRateBase = value; }

    [SerializeField]
    float dashDurationBase;
    public float DashDurationBase { get => dashDurationBase; private set => dashDurationBase = value; }

}
