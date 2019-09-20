using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public string headName;
    public float speed = 30.0f;
    public bool turningLeft;
    public bool turningRight;
    public bool movementEvent;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find(headName).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!movementEvent)
        {
            movementEvent = true;
            int leftOrRight = Random.Range(0, 2);
            if(leftOrRight == 1)
            StartCoroutine(LeftEvent());
            else
            StartCoroutine(RightEvent());
        }

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        if(turningLeft == true)
        {
            transform.Rotate(Vector3.down * 12 * Time.deltaTime);
        }
        if (turningRight == true)
        {
            transform.Rotate(Vector3.up * 12 * Time.deltaTime);
        }
    }

    IEnumerator LeftEvent()
    {
        int randTime = Random.Range(2, 15);
        int randTurningTime = Random.Range(2, 10);
        yield return new WaitForSeconds(randTime);
        turningLeft = true;
        anim.SetInteger("State", 1);
        yield return new WaitForSeconds(randTurningTime);
        turningLeft = false;
        movementEvent = false;
        anim.SetInteger("State", 3);
    }

    IEnumerator RightEvent()
    {
        int randTime = Random.Range(2, 15);
        int randTurningTime = Random.Range(2, 10);
        yield return new WaitForSeconds(randTime);
        turningRight = true;
        anim.SetInteger("State", 2);
        yield return new WaitForSeconds(randTurningTime);
        turningRight = false;
        movementEvent = false;
        anim.SetInteger("State", 4);
    }
}
