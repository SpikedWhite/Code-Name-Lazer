using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Taking Damage")]
    [SerializeField] AudioClip takingDamageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        Managesingleton();
    }

    void Managesingleton()
    {
        
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // original way of playing audio clips
    //public void PlayShootingClip()
    //{
    //    if(shootingClip != null)
    //    {
    //        AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
    //    }
    //}

    //public void PlayDamageClip()
    //{
    //    if(takingDamageClip != null)
    //    {
    //        AudioSource.PlayClipAtPoint(takingDamageClip, Camera.main.transform.position, damageVolume);
    //    }
    //}


    //more robust way?
    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            PlayClip(shootingClip, shootingVolume);
        }
    }
    public void PlayDamageClip()
    {
        if(takingDamageClip != null)
        {
            PlayClip(takingDamageClip, damageVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
    
}
