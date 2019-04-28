using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBehavior : MonoBehaviour
{
    public float duration = 20.0f;

    // Update is called once per frame
    void Update()
    {
        duration -= 1.0f * Time.deltaTime;
        if(duration <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
