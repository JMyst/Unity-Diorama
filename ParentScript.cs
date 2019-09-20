using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    public GameObject[] settlements;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.parent = settlements[0].transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.parent = settlements[1].transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.parent = settlements[2].transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.parent = settlements[3].transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            transform.parent = settlements[4].transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.parent = null;
        }
    }
}
