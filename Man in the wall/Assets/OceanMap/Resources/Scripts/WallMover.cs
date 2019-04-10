using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float speed;
    Vector3 oriPos;
    bool isWaiting = true;
    public float ZPosition = 40;
    public string[] data;
    CreateWall createNewWallObj;

    CreateWall createWallObj;

    // Start is called before the first frame update
    void Start()
    {
        oriPos.z = ZPosition;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        createWallObj = FindObjectOfType<CreateWall>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetButton("Jump") && isWaiting)
            {
                isWaiting = false;
                createWallObj.Parse();
            }

        if (transform.position.z > -ZPosition && !isWaiting){
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed * Time.deltaTime);
        }
        else
        {
            transform.position = oriPos;
            isWaiting = true;
            if (createWallObj._wallObject) Destroy(createWallObj._wallObject);
        }
    }
}
