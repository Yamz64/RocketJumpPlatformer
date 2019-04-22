using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherBehavior : MonoBehaviour
{
    public float rocketSpeed;
    public SpriteRenderer sprite;
    public Object rocket;
    private GameObject crosshair;
    private Rigidbody2D player;

    float FindAngle()
    {
        float xdistance = crosshair.transform.position.x - transform.position.x;
        float ydistance = crosshair.transform.position.y - transform.position.y;

        float theta = Mathf.Rad2Deg * Mathf.Atan(ydistance / xdistance);
        return theta;
    }

    void Fire()
    {
        GameObject rocketInstance = Instantiate(rocket, transform.position, transform.rotation) as GameObject;
        rocketInstance.GetComponent<SpriteRenderer>().sortingOrder = sprite.sortingOrder - 1;
        if (sprite.flipX == false)
        {
            rocketInstance.GetComponent<Rigidbody2D>().AddForce(rocketInstance.transform.right * (rocketSpeed + player.velocity.magnitude));
        }
        else
        {
            rocketInstance.GetComponent<SpriteRenderer>().flipX = true;
            rocketInstance.GetComponent<Rigidbody2D>().AddForce(rocketInstance.transform.right * (-rocketSpeed - player.velocity.magnitude));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        player = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform parent = transform.parent;
        SpriteRenderer pSprite = parent.GetComponent<SpriteRenderer>();
        sprite.flipX = pSprite.flipX;
        if(sprite.flipX == true)
        {
            sprite.sortingOrder = -1;
        }
        else
        {
            sprite.sortingOrder = 2;
        }
        transform.eulerAngles = new Vector3(0.0f, 0.0f, FindAngle());

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
}
