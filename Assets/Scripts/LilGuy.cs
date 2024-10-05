using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilGuy : MonoBehaviour
{
    //lil guy
    private float startPos = -3.6f;
    private float endPos = 3.5f;
    private float distance;

    //player
    private float playerProgress = 0;
    private float playery;
    private float playerStart;
    private float endy;
    Transform parent;


    void Start()
    {
        distance = endPos - startPos;
        endy = GameObject.Find("WinFlag").transform.position.y;
        parent = GetComponentInParent<Transform>();
        playerStart = parent.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerProgress = (parent.position.y - playerStart) / (endy - playerStart);
    }

    private void FixedUpdate() 
    {
        float newPos = (playerProgress * distance) + startPos;

        if(newPos > endPos)
        {
            newPos = endPos;
        }
        else if(newPos < startPos)
        {
            newPos = startPos;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, newPos, -5);
    }
}

