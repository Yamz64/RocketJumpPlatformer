using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public float eTimer = .5f;
    public float force;
    public Vector2 distance;

    // Update is called once per frame
    void Update()
    {
        eTimer -= 1.0f * Time.deltaTime;
        if(eTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();

            distance[0] = other.transform.position.x - transform.position.x;
            distance[1] = other.transform.position.y - transform.position.y;
            
            playerRb.AddForce(new Vector2(distance[0],distance[1]) * force/Mathf.Abs(Mathf.Sqrt(Mathf.Pow(distance[0],2)+Mathf.Pow(distance[1],2))));
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
