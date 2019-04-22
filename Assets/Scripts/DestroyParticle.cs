using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public float delay;

    // Update is called once per frame
    void Update()
    {
        delay -= 1.0f * Time.deltaTime;
        if(delay <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
