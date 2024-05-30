using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    PlayerHealth playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Special")]
    [SerializeField] Slider specialSlider;
    SpecialTracker specialTracker;

    [Header("Cogs Counter")]
    [SerializeField] TextMeshProUGUI cogsText;
    CogsCounter cogsCounter;

    [SerializeField] RawImage banana;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        specialTracker = FindObjectOfType<SpecialTracker>();
        cogsCounter = FindObjectOfType<CogsCounter>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        specialSlider.value = 0;
        
    }

    
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        healthSlider.maxValue = playerHealth.currentMaxHealth;
        
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        specialSlider.value = specialTracker.GetSpecial();
        cogsText.text = cogsCounter.GetCogs().ToString("0000");
    
        if(PlayerShooter.isBombReady == true)
        {
            banana.enabled = true;
        }
        else 
        {
            banana.enabled = false;
        }
    }

    
}
