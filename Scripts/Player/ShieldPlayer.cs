using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    [SerializeField] float ShieldHealth = 30;
    GameObject Player;

    public static bool isShielded = false;
    void Start()
    {
        Player = GameObject.Find("Lazer (Player)");
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        Vector2 newPos = new Vector2();
        newPos.x = Player.transform.position.x;
        newPos.y = Player.transform.position.y;
        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyDamage enemyDamage = other.GetComponent<EnemyDamage>();

        if(enemyDamage = null)
        {
            ShieldHit(enemyDamage.GetDamage());
            enemyDamage.Hit();
            
        }
    }


    void ShieldHit(float damage)
    {
        ShieldHealth -= damage;
        if(ShieldHealth <= 0)
        {
            
            Destroy(gameObject);
            isShielded = false;
        }
        
    }
}
