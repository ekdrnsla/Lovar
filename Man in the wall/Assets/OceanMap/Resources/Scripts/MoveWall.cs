using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;
    Vector3 oriPos;
    bool isWait = true;
    GameObject tubeObject;
    float YPosition;

    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
        oriPos.y = YPosition;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        tubeObject = GameObject.Find("tube");
    }

    // Update is called once per frame
    void Update()
    {
        YPosition = tubeObject.transform.position.y + tubeObject.transform.localScale.y;
        oriPos.y = YPosition;

        if (Input.GetButton("Jump"))
            isWait = false;

        if (transform.position.z > -20 && !isWait)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed * Time.deltaTime);
        else
        {
            transform.position = oriPos;
            isWait = true;
        }
    }
}
