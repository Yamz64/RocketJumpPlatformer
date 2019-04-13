using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;             //horizontal speed of player
    public float jForce;
    public float circleRadius;
    public float jumpTime;
    public float jumpTimeCounter;
    public bool isJumping;
    public bool isGrounded;
    public Transform crosshair;
    public Vector2 movement;
    private Animator anim;          //animator component attached to player
    private SpriteRenderer sprite;  //SpriteRenderer component attached to player
    private Rigidbody2D rb;         //Rigidbody2D component attached to player

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Transform>();
        anim = GetComponent<Animator>();            //anim is set equal to the attached Animator component
        sprite = GetComponent<SpriteRenderer>();    //sprite is set equal to the attached SpriteRenderer component
        rb = GetComponent<Rigidbody2D>();           //rb is set equal to the attached Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jForce);
        }

        if(isJumping == true && Input.GetKey(KeyCode.W))
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else if(jumpTimeCounter < 0)
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
        movement.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
        if(crosshair.transform.position.x >= transform.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}