using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtons : MonoBehaviour
{

    
    GameObject player;
    PlayerStats playerStats;
    WeaponStats weaponStats;
    CogsCounter cogsCounter;
    

    [Header("Text")]
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI CostText;
    [SerializeField] TextMeshProUGUI InfoText;

    Button[] buttons;

    GameObject UIUPGRADE;
    UIUpgrade uiUpgrade;


    int BaseLevel = 0;
    [SerializeField] int BasePrice;
    
    int Level;
    int Price;

    int Wallet;


    void Awake()
    {
        cogsCounter = FindObjectOfType<CogsCounter>();
        
      
        Level = BaseLevel;
        Price = BasePrice;

        
        UIUPGRADE = GameObject.Find("UpgradeScreen");

        player = GameObject.Find("Lazer (Player)");
        
        
        
        
    }

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        weaponStats = player.GetComponent<WeaponStats>();
        
        uiUpgrade = UIUPGRADE.GetComponent<UIUpgrade>();
        buttons = FindObjectsOfType<Button>();
        
        if(LevelText == null) {return;}
        LevelText.text = "Level: " + Level.ToString("00");
        CostText.text = "Cost: " + Price.ToString("000");
        
    }

    void Update()
    {
        Wallet = cogsCounter.GetCogs();
        
        PauseCheck();


    }

    

    void PauseCheck()
    {
        if(UIUpgrade.isPaused)
        {
            
            foreach(Button upgradeButton in buttons)
            {
                UIButtons uiButtons = upgradeButton.GetComponent<UIButtons>();
                if(uiButtons != null)
                {
                    upgradeButton.interactable = false;
                }
            }
        }
        else if(UIUpgrade.isPaused == false)
        {
            foreach(Button upgradeButton in buttons)
            {
                UIButtons uiButtons = upgradeButton.GetComponent<UIButtons>();
                if(uiButtons != null)
                {
                    upgradeButton.interactable = true;
                }
            }
        }
    }

    public void NextWave()
    {
        uiUpgrade.upgradeTimer = uiUpgrade.upgradeDuration;
        
    }    

    public void UpgradeHealth()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));
            
            playerStats.HealthMod += 10;


            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            LevelText.text = "Level: 20";
            
            return;
        }
    }

    public void UpgradeMoveSpeed()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));
            
            playerStats.MoveSpeedMod += .1f;
            
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            
            return;
        }
    }

    public void UpgradeFireRate()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));
            
            playerStats.FireRateMod += .1f;
            
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            return;
        }
    }

    public void UpgradeDash()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));

            playerStats.DashMod += .01f;
            
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            return;
        }
    }
    



    public void UpgradeDamage()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));

            weaponStats.DamageMod += 10;
            
            
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            return;
        }
    }

    

    public void UpgradeProjSpeed()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));
            
            weaponStats.ProjSpeedMod += .1f;
            
        
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            return;
        }
    }

    public void UpgrageSplashDamage()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));
            
            weaponStats.SplashDamageMod += 5;
            
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            return;
        }
    }

    public void UpgradeSplashRange()
    {
        if(Wallet >= Price && Level != 20)
        {
            Level++;
            cogsCounter.ChangeCogs(-Price);
            Price = Mathf.RoundToInt(Price * Mathf.Pow(Level, .1f));
            

            weaponStats.SplashRangeMod += .1f;
            
        
            LevelText.text = "Level: " + Level.ToString("00");
            CostText.text = "Cost: " + Price.ToString("000");
            InfoText.text = "Purchase complete";
        }
        else if( Wallet < Price)
        {
            InfoText.text = "You Are Too Broke";
            return;
        }
        else if(Level == 20)
        {
            CostText.text = "Cost: N/A";
            return;
        }
    }
}
