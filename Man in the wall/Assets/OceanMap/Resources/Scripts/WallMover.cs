using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float speed = 1500;
    Vector3 oriPos;
    bool isCreateWall = false;
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
        transform.position = new Vector3(0, 0, ZPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && !createWallObj._wallObject && !isCreateWall && transform.position.z == ZPosition && playerObj.transform.position.y >= 0)
        {
            isCreateWall = true;
            StartCoroutine(CreateNewWall());
            Debug.Log(1);
        }
        else if (transform.localScale.x <= offset) isMoving = true;
        else if (isMoving)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed * Time.deltaTime);
            if (transform.position.z < -ZPosition / 4.5f)
            {
                isMoving = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                animator.SetBool("isGo", false);
                Destroy(createWallObj._wallObject);
                transform.position = oriPos;
                isCreateWall = false;
            }
        }
    }

    IEnumerator CreateNewWall()
    {
        yield return new WaitUntil(() => createWallObj.Parse());
        animator.SetBool("isGo", true);
    }
}
