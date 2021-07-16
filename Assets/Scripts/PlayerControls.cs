using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5, jumpForce = 5;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    Player player;
    bool grounded = false;
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.isAlive)
        {
            Control();
            CheckInvincibility();
        }
    }

    void CheckInvincibility()
    {
        if (!player.isInvincible) return;

        player.invTime += Time.deltaTime;
        if (player.invTime >= 2)
        {
            player.invTime = 0;
            player.isInvincible = false;
        }
    }

    public void Hit()
    {
        if (player.isInvincible || player.hp == 0) return;

        animator.SetTrigger("hit");
        player.hp--;
        player.isInvincible = true;
        if (player.hp <= 0)
        {
            rb.velocity = Vector2.zero;
            player.isAlive = false;
            animator.SetTrigger("dead");
        }
    }

    void Control()
    {
        float velX = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velX = speed;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velX = -speed;
            sprite.flipX = false;
        }

        rb.velocity = new Vector2(velX, rb.velocity.y);

        animator.SetBool("isMoving", velX != 0);
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityY", rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            player.diamonds++;
            if (player.diamonds == player.totalDiamonds)
            {
                player.isWinner = true;
            }
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("heart") && player.hp < player.maxHp)
        {
            player.hp++;
            Destroy(collision.gameObject);
        }
    }
}
