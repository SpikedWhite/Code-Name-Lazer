using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private float Score;

    static ScoreKeeper instance;

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

    public void ChangeScore(int value)
    {
        Score += value;
        Mathf.Clamp(Score, 0, int.MaxValue);
    }

    public float GetScore()
    {
        return Score;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    
}
