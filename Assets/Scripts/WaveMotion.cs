using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour
{
    public GameObject wave; 
    public float amplitude = 2f, speed = 1f;

    private Vector3 startPos; 

    void Start() {
        startPos = wave.transform.position;
    }

    void FixedUpdate() {

        float newX = startPos.x + Mathf.Sin(Time.time * speed) * amplitude;

        wave.transform.position = new Vector3(newX, wave.transform.position.y, wave.transform.position.z);
    }
}