using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life;
    public int scale;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 basePos = GetComponentInParent<Transform>().position;
        for (int i = 1; i < life + 1; i++)
        {
            GameObject lifeObj = Instantiate(Resources.Load("Modelings/Love"), new Vector3(basePos.x * i, basePos.y, basePos.z), Quaternion.Euler(-90, 0, 0), transform) as GameObject;
            lifeObj.name = "love" + i;
            lifeObj.transform.localScale = new Vector3(scale, scale, scale);
            lifeObj.layer = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
