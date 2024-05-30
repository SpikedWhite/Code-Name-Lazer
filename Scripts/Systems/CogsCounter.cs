using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogsCounter : MonoBehaviour
{
    public int TotalCogs;
    private int CogsCap = 9999;

    static CogsCounter instance;

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

    public void ChangeCogs(int value)
    {
        if(TotalCogs < CogsCap)
        {
            TotalCogs += value;
        }
        else if(TotalCogs > CogsCap)
        {
            TotalCogs = CogsCap;
        }
    }

    public int GetCogs()
    {
        return TotalCogs;
    }

    public void ResetCogs()
    {
        TotalCogs = 0;
    }

}
