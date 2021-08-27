using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int speed = 3;
    [SerializeField] private int damage = 50;

    private void Start()
    {
        
    }
    private void Update()
    {
        Strike();    
    }

    void Strike()
    {
        //transform.Rotate(20f, 0f, 10f);
        transform.Translate(Vector2.left * speed *  Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        var attacker = collision.gameObject.GetComponent<Attacker>();

        if(health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
