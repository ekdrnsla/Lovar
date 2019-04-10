// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CreateNewWall : CreateWall
// {
//     public string[] data;
//     // bool delay = false;
//     public bool isNewWall = true;
//     float parentZPos;
//     WallMover wallMoverObj;

//     // Start is called before the first frame update
//     void Start()
//     {
//         gameObject.AddComponent<Rigidbody>();
//         gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
//         gameObject.GetComponent<Rigidbody>().useGravity = false;

//         parentZPos = GetComponentInParent<Transform>().position.z;
//         wallMoverObj = FindObjectOfType<WallMover>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // if (!_wallObject && isNewWall)
//         // if (!delay && parentZPos != wallMoverObj.ZPosition)
//         {
//             // delay = true;
//             // StartCoroutine(createNewWall(0.5f));
//             // createNewWall();
//             isNewWall = false;
//         }
//         // else if (_wallObject && !isNewWall) Destroy(_wallObject);
//     }

//     // void createNewWall()
//     // {
//     //     int randomInt = Random.Range(0, 2);
//     //     switch (randomInt)
//     //     {
//     //         case 0:
//     //             Parse(data[0]);
//     //             break;
//     //         case 1:
//     //             Parse(data[1]);
//     //             break;
//     //     }
//     // }

//     // IEnumerator createNewWall(float _sec)
//     // {
//     //     int randomInt = Random.Range(0, 2);
//     //     switch (randomInt)
//     //     {
//     //         case 0:
//     //             Parse(data[0]);
//     //             break;
//     //         case 1:
//     //             Parse(data[1]);
//     //             break;
//     //     }
//     //     yield return new WaitForSeconds(_sec);
//     //     delay = false;
//     // }
// }