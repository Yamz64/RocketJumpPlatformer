using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public float eTimer = .5f;

    // Update is called once per frame
    void Update()
    {
        eTimer -= 1.0f * Time.deltaTime;
        if(eTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
