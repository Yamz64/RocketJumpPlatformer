using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    public bool isCurrentCheckpoint;
    private Animator anim;
    private SpriteRenderer rend;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.checkpoint = transform.position;
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement currentCheckpoint = player.GetComponent<PlayerMovement>();
        if (currentCheckpoint.checkpoint == new Vector2(transform.position.x, transform.position.y))
        {
            anim.speed = 2.0f;
            rend.color = Color.yellow;
        }
        else
        {
            anim.speed = 1.0f;
            rend.color = Color.white;
        }
    }
}
