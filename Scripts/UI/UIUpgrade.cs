using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgrade : MonoBehaviour
{
    GameObject Player;
    EnemySpawner enemySpawner;
    
    PlayerControls playerControls;
    PlayerShooter playerShooter;
    GameObject pauseMenu;
    
    

    public float upgradeTimer;
    public float upgradeDuration = 15;

    bool timerStart;
    public static bool isPaused = false;
    
    [SerializeField] Slider timerSlider;
    
    Button button;

    [HideInInspector] public bool hasDisplayed = false;
    [HideInInspector] public bool UpgradeDone = false;
    [HideInInspector] public static bool isUpgrading = false;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        Player = GameObject.Find("Lazer (Player)");
        pauseMenu = GameObject.Find("UpgradePanel");
        
        
        
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        playerControls = Player.GetComponent<PlayerControls>();
        playerShooter = Player.GetComponent<PlayerShooter>();
        timerSlider.maxValue = upgradeDuration;
    }

    void Update()
    {     
        //StartCoroutine (DisplayUpgrades());
        
        if(timerStart == true)
        {
            upgradeTimer += Time.deltaTime;
            timerSlider.value = upgradeTimer;
            if(upgradeTimer >= upgradeDuration)
            {
                RemoveUpgrades();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resumegame();
            }
            else
            {
                PauseGame();
            }
        }

        
    }


    public IEnumerator DisplayUpgrades()
    {
        UpgradeDone = false;
        if(hasDisplayed == false)
        {

            hasDisplayed = true;
        
            yield return new WaitForSeconds(2.5f); 
            
            timerStart = true;
            upgradeTimer = 0;
            pauseMenu.SetActive(true);
            playerControls.enabled = false;
            playerShooter.enabled = false;
            

        }
    }
    

    void RemoveUpgrades()
    {
        
        timerStart = false;
        pauseMenu.SetActive(false);
        UpgradeDone = true;
        upgradeTimer = 0;
        playerControls.enabled = true;
        playerShooter.enabled = true;
    }


    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resumegame()
    {
        if(isPaused == false) {return;}

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
