using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
    //My attempt at creating the camera shake routine (doesn't work)
    //public void Play()
    //{
    //    Shaking = true;
    //    StartCoroutine(Shake());
    //    Shaking = false;
    //    StopCoroutine(Shake());
    //}
//
    //IEnumerator Shake()
    //{
    //    while(Shaking = true)
    //    {
    //        transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
    //        yield return new WaitForEndOfFrame();
    //    }
    //    transform.position = initialPosition;
    //}
//
    
}
