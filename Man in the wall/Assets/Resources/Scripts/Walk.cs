﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed;
    private Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            vector3.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector3.x != 0)
            {
                transform.Translate(vector3.x * speed, 0, 0);
            }
            else if(vector3.y != 0)
            {
                transform.Translate(0, vector3.y * speed, 0);
            }
        }
    }
}
