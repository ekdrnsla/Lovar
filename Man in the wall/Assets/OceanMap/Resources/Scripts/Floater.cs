using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private Transform seaPlane;
    private Cloth planeCloth;
    private int closestVertexIndex = 0;
    public float height;
    // private int closestVertexIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        seaPlane = GameObject.Find("water").transform;
        planeCloth = seaPlane.GetComponent<Cloth>();
    }

    // Update is called once per frame
    void Update()
    {
        GetClosestVertex();
    }

    void GetClosestVertex()
    {
        for (int i = 0; i < planeCloth.vertices.Length; i++)
        {
            float distance = Vector3.Distance(planeCloth.vertices[i], transform.position);
            float closestDistance = Vector3.Distance(planeCloth.vertices[closestVertexIndex], transform.position);
            if (distance < closestDistance)
                closestVertexIndex = i;
        }

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            planeCloth.vertices[closestVertexIndex].y / 5 + height,
            transform.localPosition.z
        );

        // for (int i = 0; i < planeCloth.vertices.Length; i++)
        // {
        //     if (closestVertexIndex == -1)
        //         closestVertexIndex = i;
        //     float distance = Vector3.Distance(planeCloth.vertices[i], transform.position);
        //     float closestDistance = Vector3.Distance(planeCloth.vertices[closestVertexIndex], transform.position);

        //     if (distance < closestDistance)
        //         closestVertexIndex = i;
        // }
        // transform.localPosition = new Vector3(
        //     transform.localPosition.x,
        //     planeCloth.vertices[closestVertexIndex].y / 10,
        //     transform.localPosition.z
        // );
    }
}
