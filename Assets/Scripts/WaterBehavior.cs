using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public Object splash;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.FindGameObjectWithTag("Splash") == null)
        {
            if (other.tag == "Player")
            {
                Instantiate(splash, new Vector2(other.transform.position.x, other.transform.position.y - .75f), other.transform.rotation);
                PlayerMovement movement = other.GetComponent<PlayerMovement>();
                movement.inWater = true;
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (GameObject.FindGameObjectWithTag("Splash") == null)
        {
            if (other.tag == "Player")
            {
                Instantiate(splash, new Vector2(other.transform.position.x, other.transform.position.y - .75f), other.transform.rotation);
                PlayerMovement movement = other.GetComponent<PlayerMovement>();
                movement.inWater = false;
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*2);
            }
        }
    }
}
