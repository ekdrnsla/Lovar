using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;
    bool isWait = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isWait = false;

        if (transform.position.z > -3 && !isWait)
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.back * speed * Time.deltaTime;
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 19);
            isWait = true;
        }
    }
}
