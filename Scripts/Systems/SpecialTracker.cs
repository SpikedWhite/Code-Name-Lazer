using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTracker : MonoBehaviour
{
    
    private int SpecialCapBase = 100;
    
    [HideInInspector]
    public int SpecialAmount;
    [HideInInspector]
    public int SpecialCap;
    [HideInInspector]
    public bool SpecialActive = false; 
    [HideInInspector]
    public int SpecialCharges = 0;

    static SpecialTracker instance;

    void Awake()
    {
        SpecialCap = SpecialCapBase;
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

    public void ChangeSpecial(int value)
    {
        if(SpecialAmount < SpecialCap)
        {
            SpecialAmount += value;
        }
        else if(SpecialAmount > SpecialCap)
        {
            SpecialAmount = SpecialCap;
        }
    }

    public void UseSpecial()
    {
        if(SpecialActive && SpecialCharges > 0)
        {
            SpecialAmount -= 0;
            SpecialCharges -= 1;
        }
        else if(SpecialActive == false)
        {
            SpecialAmount -= 100;
        }
    }

    public float GetSpecial()
    {
        
        return SpecialAmount;
        
    }

    public float GetSpecialCap()
    {
        Debug.Log(SpecialCap);
        return SpecialCap;
        
    }

    public void ResetSpecial()
    {
        SpecialAmount = 0;
    }


}
