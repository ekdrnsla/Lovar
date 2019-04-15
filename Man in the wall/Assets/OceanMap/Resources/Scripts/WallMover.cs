using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float speed = 1500;
    Vector3 oriPos;
    bool CreateNewWallDelay = false;
    bool isMoving = false;
    public float ZPosition = 50;
    public float offset = 0.1f;
    CreateWall createWallObj;
    Animator animator;
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        oriPos.z = ZPosition;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        createWallObj = FindObjectOfType<CreateWall>();
        animator = GetComponent<Animator>();
        playerObj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!CreateNewWallDelay && !createWallObj._wallObject && Input.GetButton("Jump") && transform.position.z >= ZPosition && playerObj.transform.position.y >= 0) StartCoroutine(CreateNewWall());
        if (transform.localScale.x <= offset) isMoving = true;

        if (transform.position.z > -ZPosition / 4 && isMoving)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed * Time.deltaTime);
            if (transform.position.z < -ZPosition / 4.5f)
            {
                animator.SetBool("isGo", false);
                Destroy(createWallObj._wallObject);
            }
        }
        else
        {
            transform.position = oriPos;
            isMoving = false;
        }
    }

    IEnumerator CreateNewWall()
    {
        CreateNewWallDelay = true;
        yield return new WaitUntil(() => createWallObj.Parse());
        animator.SetBool("isGo", true);
        CreateNewWallDelay = false;
    }
}
