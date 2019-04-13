using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBehavior : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Input.mousePosition.x/ Camera.main.pixelWidth, Input.mousePosition.y/Camera.main.pixelHeight, 10.0f));
    }
}
