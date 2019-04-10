using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Vector3 oriPos;
    public float limit = 20;

    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -limit || transform.position.x > limit || transform.position.y < -limit || transform.position.z < -limit || transform.position.z > limit)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.SetPositionAndRotation(oriPos, Quaternion.Euler(0, 0, 0));
        }

    }
}
