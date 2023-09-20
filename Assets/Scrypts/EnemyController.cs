using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 2.0f;
    public float changeTime = 3.0f;
    public ParticleSystem smokeEffect;
    public bool vertical;
    public AudioClip fixClip;
    private AudioSource audioSource;

    bool isBroken = true;
    float timer;
    int direction = 1;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBroken)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = changeTime;
            direction = -direction;
        }
    }

    private void FixedUpdate()
    {
        if (!isBroken)
        {
            return;
        }

        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + speed * direction * Time.deltaTime;
        }
        else 
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + speed * direction * Time.deltaTime;
        }

    rigidbody2d.MovePosition(position);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();

        if(player!=null)
            player.ChangeHealth(-1);
    }

    public void Fix()
    {
        isBroken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        audioSource.Stop();
        audioSource.PlayOneShot(fixClip);
    }
}
