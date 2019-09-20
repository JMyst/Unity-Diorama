using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
    public float speed;
    public int time;
    public bool moveUp;
    public bool moveDown;
    public bool walkEvent;
    int upOrDown;
    // Start is called before the first frame update
    void Start()
    {
        upOrDown = Random.Range(0, 2);
        if (upOrDown == 0)
            moveUp = true;
        else
            moveDown = true;
        speed = Random.Range(0.8f, 1.4f);
        time = Random.Range(15, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if(!walkEvent)
        StartCoroutine(WalkEvent());

        if (moveUp)
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        if (moveDown)
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
    }

    IEnumerator WalkEvent()
    {
        walkEvent = true;
        yield return new WaitForSeconds(time);
        if(moveUp == true)
        {
            moveUp = false;
            moveDown = true;
        }
        else
        {
            moveUp = true;
            moveDown = false;
        }
        walkEvent = false;
    }
}
