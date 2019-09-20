using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Makes objects float up & down while gently spinning.
public class Float : MonoBehaviour
{
    // User Inputs
    //public float degreesPerSecond = 15.0f;
    public bool randomFloating;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        if(randomFloating == true)
        {
            frequency = Random.Range(0.1f, 1.6f);
            amplitude = Random.Range(0.2f, 3.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}