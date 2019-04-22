using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;             //horizontal speed of player
    public float jForce;
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
        if(isGrounded == true && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jForce);
        }

        if(isJumping == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
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
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            movement.x = Input.GetAxis("Horizontal") * speed;
        }
        else
        {
            movement.x = rb.velocity.x;
        }
        if (isGrounded == true)
        {
            rb.velocity = new Vector2(movement.x, rb.velocity.y);
        }
        else
        {
            if (rb.velocity.x > movement.x && Input.GetKey(KeyCode.A))
            {
                if (!(movement.x / Mathf.Abs(movement.x) == 1.0f))
                {
                    rb.velocity += new Vector2(movement.x, 0.0f);
                }
            }else if(rb.velocity.x < movement.x && Input.GetKey(KeyCode.D))
            {
                if (!(movement.x / Mathf.Abs(movement.x) == -1.0f))
                {
                    rb.velocity += new Vector2(movement.x, 0.0f);
                }
            }
        }
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