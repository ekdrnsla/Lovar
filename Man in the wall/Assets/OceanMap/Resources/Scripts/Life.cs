using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life;
    public int scale;
    public float XPos;
    public float XSpace;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 basePos = GetComponentInParent<Transform>().position;
        for (int i = 1; i < life + 1; i++)
        {
            GameObject lifeObj = Instantiate(Resources.Load("Modelings/Love"), new Vector3(i * XSpace + XPos, basePos.y, basePos.z), Quaternion.identity, transform) as GameObject;
            lifeObj.name = "love" + i;
            lifeObj.transform.localScale = new Vector3(scale, scale, scale);
            lifeObj.layer = 5;
            lifeObj.AddComponent<Floater>();
            lifeObj.transform.LookAt(GameObject.Find("player").transform);
            lifeObj.transform.Rotate(-90, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
