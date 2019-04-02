using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    Mesh mesh;
    public Material material;
    GetData getData;

    // Start is called before the first frame update
    void Start()
    {
        getData = new GetData();

        mesh = gameObject.AddComponent<MeshFilter>().mesh;
        gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
        gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;

        UpdateVectors();
        //UpdateMesh();
        GetComponent<MeshCollider>().convex = true;

        // for(int i = 0; i < getData.vertices.Length; i++) Debug.Log(getData.vertices[i]);
        UpdateMesh();
        transform.SetPositionAndRotation(new Vector3(-getData.wallWidth / 2, getData.wallHeight / 2, 0), Quaternion.Euler(180, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            transform.position += new Vector3(0.3f, 0, 0);
            UpdateVectors();
            UpdateMesh();
        }
    }

    void UpdateVectors()
    {

    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = getData.vertices;
        mesh.triangles = getData.triangles;
        mesh.RecalculateNormals();
    }
}
