using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public float eTimer = .5f;
    public float force;
    public Vector2 distance;
    public Object[] crateGib;

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

        }else if((other.tag == "WeakBox") && (other.name.Substring(0,12) == "WeakBoxLarge"))
        {
            Vector3 boxScale = other.gameObject.transform.localScale;
            Vector3 boxPos = other.gameObject.transform.position;
            Quaternion boxRot = other.gameObject.transform.rotation;

            GameObject boxGib = Instantiate(crateGib[0], boxPos, boxRot) as GameObject;
            boxGib.transform.localScale = boxScale/7.5f;
            Destroy(other.gameObject);

        }else if ((other.tag == "WeakBox") && (other.name.Substring(0,12) == "WeakBoxSmall"))
        {
            Vector3 boxScale = other.gameObject.transform.localScale;
            Vector3 boxPos = other.gameObject.transform.position;
            Quaternion boxRot = other.gameObject.transform.rotation;

            GameObject boxGib = Instantiate(crateGib[1], boxPos, boxRot) as GameObject;
            boxGib.transform.localScale = boxScale / 15.0f;
            Destroy(other.gameObject);

        }else if ((other.tag == "StrongBox") && (other.name.Substring(0, 14) == "StrongBoxLarge"))
        {
            Rigidbody2D lBoxRb = other.gameObject.GetComponent<Rigidbody2D>();

            distance[0] = other.transform.position.x - transform.position.x;
            distance[1] = other.transform.position.y - transform.position.y;

            lBoxRb.AddForce(new Vector2(distance[0], distance[1]) * force * 10 / Mathf.Abs(Mathf.Sqrt(Mathf.Pow(distance[0], 2) + Mathf.Pow(distance[1], 2))));
        }
        else if ((other.tag == "StrongBox") && (other.name.Substring(0, 14) == "StrongBoxSmall"))
        {
            Rigidbody2D sBoxRb = other.gameObject.GetComponent<Rigidbody2D>();

            distance[0] = other.transform.position.x - transform.position.x;
            distance[1] = other.transform.position.y - transform.position.y;

            sBoxRb.AddForce(new Vector2(distance[0], distance[1]) * force * 6 / Mathf.Abs(Mathf.Sqrt(Mathf.Pow(distance[0], 2) + Mathf.Pow(distance[1], 2))));
        }
    }
}
