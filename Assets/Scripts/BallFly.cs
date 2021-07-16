using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFly : MonoBehaviour
{
    public float speed;
    Animator animator;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("boom");
            collision.gameObject.GetComponent<PlayerControls>().Hit();
            rb.velocity = Vector2.zero;
            Destroy(gameObject, 0.5f);
            
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("boom");
            Destroy(gameObject, 0.5f);
        }
    }
}
