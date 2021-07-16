using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject player;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            animator.SetTrigger("boom");
            Invoke("Boom", .8f);
        }
    }

    void Boom()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= 1.5f)
        {
            player.GetComponent<PlayerControls>().Hit();
        }
        Destroy(gameObject);
    }
}
