using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;
    Vector3 oriPos;
    bool isWait = true;

    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
            isWait = false;

        if (transform.position.z > -3 && !isWait)
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.back * speed;
        else
        {
            transform.position = oriPos;
            isWait = true;
        }
    }
}
