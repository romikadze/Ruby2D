using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float timer = 5f;
    bool isTimerStarted;

    Rigidbody2D rigidbody2d;    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerStarted)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Destroy(gameObject);
                timer = 5f;
                isTimerStarted = false;
            }
        }
        
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        isTimerStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        EnemyController enemy = collision.collider.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }
        Destroy(gameObject);
    }
}
