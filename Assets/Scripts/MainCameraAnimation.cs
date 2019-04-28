using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAnimation : MonoBehaviour
{
    public bool animStart;
    private GameObject player;
    private Animator anim;
    private Vector3 iniPos;

    void MoveTowards(Vector2 endPos, float time)
    {
        if (animStart == false)
        {
            iniPos = transform.position;
            animStart = true;
        }
        if (transform.position.x < Mathf.Abs(endPos.x) && transform.position.y < Mathf.Abs(endPos.y))
        {
            transform.position += new Vector3((Time.deltaTime / time) * (endPos.x - iniPos.x), (Time.deltaTime / time) * (endPos.y - iniPos.y), 0.0f);
        }
        else
        {
            transform.position = new Vector3(endPos.x, endPos.y, -10.0f);
            animStart = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > -1.93f && player.transform.position.x < 175.6f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        if (player.transform.position.y > -2.77)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        if (player.transform.position.x >= 182.0f && player.transform.position.x <= 214.0f)
        {
            if(player.transform.position.y >= -41.6f && player.transform.position.y <= -10.8f){
                MoveTowards(new Vector2(198f, -27.2f), 1.0f);
            }
        }
    }
}
