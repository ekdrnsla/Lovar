using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yachts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // createYacht();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 1 * Time.deltaTime);
    }

    // void createYacht()
    // {
    //     GameObject yacht = Resources.Load("Modelings/yacht") as GameObject;
    //     int randomPos = Random.Range(100, 200);
    //     var Object = Instantiate(yacht, new Vector3(randomPos, randomPos, 0), Quaternion.identity);
    //     Object.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    //     Object.transform.SetParent(transform);
    // }
}
