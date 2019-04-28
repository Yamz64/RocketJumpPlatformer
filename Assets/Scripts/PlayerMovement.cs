using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;             //horizontal speed of player
    public float jForce;
    public float jumpTime;
    public float jumpTimeCounter;
    public float waterDrag;
    public bool isJumping;
    public bool isGrounded;
    public bool inWater;
    public Transform crosshair;
    public Vector2 movement;
    public Vector2 checkpoint;
    private Animator anim;          //animator component attached to player
    private SpriteRenderer sprite;  //SpriteRenderer component attached to player
    private Rigidbody2D rb;         //Rigidbody2D component attached to player

    public void Die()
    {
        transform.position = checkpoint;
        rb.velocity = Vector2.zero;
        Camera.main.transform.position = new Vector3(-1.93f, -2.77f, -10.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = new Vector2(-16.725f, -10.355f);
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Transform>();
        anim = GetComponent<Animator>();            //anim is set equal to the attached Animator component
        sprite = GetComponent<SpriteRenderer>();    //sprite is set equal to the attached SpriteRenderer component
        rb = GetComponent<Rigidbody2D>();           //rb is set equal to the attached Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        if(inWater != true)
        {
            rb.gravityScale = 3.0f;
            waterDrag = 0.0f;
            jumpTime = .35f;
            anim.speed = 1.0f;
        }
        else
        {
            rb.gravityScale = 1.0f;
            waterDrag = 5.0f;
            jumpTime = .7f;
            anim.speed = .5f;
        }
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
            if(movement.x/Mathf.Abs(movement.x) == 1.0f)
            {
                movement.x -= waterDrag * Mathf.Abs(Input.GetAxis("Horizontal"));
            }
            else
            {
                movement.x += waterDrag * Mathf.Abs(Input.GetAxis("Horizontal"));
            }
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
            BoxCollider2D[] hitboxes = GetComponents<BoxCollider2D>();
            hitboxes[0].offset = new Vector2(.01f, hitboxes[0].offset.y);
            hitboxes[1].offset = new Vector2(.01f, hitboxes[1].offset.y);
            hitboxes[2].offset = new Vector2(.0525f, hitboxes[2].offset.y);
            hitboxes[3].offset = new Vector2(-.0325f, hitboxes[3].offset.y);
        }
        else
        {
            sprite.flipX = true;
            BoxCollider2D[] hitboxes = GetComponents<BoxCollider2D>();
            hitboxes[0].offset = new Vector2(-.01f, hitboxes[0].offset.y);
            hitboxes[1].offset = new Vector2(-.01f, hitboxes[1].offset.y);
            hitboxes[2].offset = new Vector2(-.0525f, hitboxes[2].offset.y);
            hitboxes[3].offset = new Vector2(.0325f, hitboxes[3].offset.y);
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
        if (other.tag != "Water")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Water")
        {
            isGrounded = false;
        }
    }
}