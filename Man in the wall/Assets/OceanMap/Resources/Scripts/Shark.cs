using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    GameObject playerObj;
    Vector3 oriPos;
    Quaternion oriRot;
    Vector3 dir;
    public float moveSpeed = 0.5f;
    public float rotSpeed = 1;
    public float collisionOffset = 1;

    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
        oriRot = transform.rotation;
        playerObj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.transform.position.y > 0)
            transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        else
        {
            dir = playerObj.transform.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, dir, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);

            if (playerObj.transform.position.y <= -playerObj.GetComponent<PlayerCollision>().YLimit + collisionOffset)
            {
                transform.position = oriPos;
                transform.rotation = oriRot;
            }
        }
    }
}
