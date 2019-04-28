using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBasherBehavior : MonoBehaviour
{
    public float speed;
    public float leftbound;
    public float rightbound;
    public bool right;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(right == true)
        {
            rb.velocity = new Vector2 (speed, 0.0f);
            sprite.flipX = false;
            
            if(transform.localPosition.x >= rightbound)
            {
                right = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0.0f);
            sprite.flipX = true;

            if(transform.localPosition.x <= leftbound)
            {
                right = true;
            }
        }
    }
}
