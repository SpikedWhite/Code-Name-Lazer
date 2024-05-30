using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    
    PlayerStats playerStats;
    GameObject Player;

    ParticleSystem nukeEffect;
    
    Vector2 rawInput;
    Vector2 moveDirection;

    Rigidbody2D rbPlayer;
    
    PlayerShooter playershooter;
    SpecialTracker specialTracker;

    GameObject[] Enemies;
    

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingTop;
    
    Vector2 minBounds;
    Vector2 maxBounds;

    float currentMoveSpeed;

    [Header("Dash Attributes")]
    float dashDuration;
    [SerializeField] float currentDashSpeed;
    [SerializeField] float currentDashCooldown;
    
    bool canDash = true;
    bool isDashing = false;
    bool canSpecial = true;

    
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
        playershooter = GetComponent<PlayerShooter>();
        
        specialTracker = FindObjectOfType<SpecialTracker>();

        nukeEffect = playerStats.playerNukeEffect;
    }

    void Start()
    {   
        
        currentMoveSpeed = playerStats.MoveSpeed;
        InitBounds();
    }

    void Update()
    {
        currentMoveSpeed = playerStats.GetMoveSpeed();
        dashDuration = playerStats.GetDashDuration();
        Movement();

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
    
        moveDirection = new Vector2(moveX, moveY).normalized;
    }


    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }


    void Movement()
    {
        if(isDashing){return;}

        Vector2 delta = rawInput * currentMoveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;

        
    }


    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }


    void OnFire(InputValue value)
    {
        if(!UIUpgrade.isPaused && !isDashing)
        {
            if(playershooter != null)
            {
                playershooter.isFiring = value.isPressed;
            }
        }
    }

    void OnSecondary(InputValue value)
    {
        if(playershooter.enabled == false){return;}
        if(!UIUpgrade.isPaused && !isDashing)
        {
            
            if(playershooter != null)
            {
                StartCoroutine(playershooter.Bananabomb());
            }
        }
    }


    void OnShift(InputValue value)
    {
        if(!UIUpgrade.isPaused && canDash)
        {
            StartCoroutine(Dash());
            
        }

    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        
        rbPlayer.velocity = new Vector2(moveDirection.x * currentDashSpeed, moveDirection.y * currentDashSpeed);
        yield return new WaitForSeconds(dashDuration);
        rbPlayer.velocity = new Vector2(0, 0);
        isDashing = false;
        yield return new WaitForSeconds(currentDashCooldown);
        canDash = true;

    }


    //an attempt at making a dash function without involving velocity

        //Vector2 delta2 = rawInput * currentDashSpeed * dashDuration;
        //Vector2 newPosition = new Vector2();
        //newPosition.x = Mathf.Clamp(transform.position.x + delta2.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        //newPosition.y = Mathf.Clamp(transform.position.y + delta2.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        //transform.position = newPosition;
        //yield return new WaitForSeconds(dashDuration);
        //isDashing = false;
        //yield return new WaitForSeconds(currentDashCooldown);
        //canDash = true;


    void OnSpecial(InputValue value)
    {

        StartCoroutine(nukeSpecial());

    }


    public IEnumerator nukeSpecial()
    {
        if(canSpecial)
        {
            canSpecial = false;
        if(specialTracker.GetSpecial() >= specialTracker.GetSpecialCap())
        {
            specialTracker.UseSpecial();
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
            foreach(GameObject enemy in Enemies)
            {  
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1000);
                }
            }
            if(nukeEffect != null)
            {
            ParticleSystem nukeInstance = Instantiate(nukeEffect, transform.position, Quaternion.identity);
            Destroy(nukeInstance.gameObject, nukeInstance.main.duration + nukeInstance.main.startLifetime.constantMax);
            }

            yield return new WaitForSeconds(2);
            canSpecial = true;
            Debug.Log("wait over");
        }
        }
    }

}
