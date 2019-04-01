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
        GL.wireframe = true;
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

    // void UpdateVectors()
    // {
    //     vertices = new Vector3[]
    //     {
    //         //앞
    //         new Vector3(-1, 1, -1), //좌상
    //         new Vector3(1, 1, -1), //우상
    //         new Vector3(1, -1, -1), //우하
    //         new Vector3(-1, -1, -1), //좌하

    //         //왼
    //         new Vector3(1, 1, -1), //좌상
    //         new Vector3(1, 1, 1), //우상
    //         new Vector3(1, -1, 1), //우하
    //         new Vector3(1, -1, -1), //좌하

    //         //뒤
    //         new Vector3(1, 1, 1), //좌상
    //         new Vector3(-1, 1, 1), //우상
    //         new Vector3(-1, -1, 1), //우하
    //         new Vector3(1, -1, 1), //좌하

    //         //오
    //         new Vector3(-1, 1, 1), //좌상
    //         new Vector3(-1, 1, -1), //우상
    //         new Vector3(-1, -1, -1), //우하
    //         new Vector3(-1, -1, 1), //좌하

    //         //위
    //         new Vector3(-1, 1, 1), //좌상
    //         new Vector3(1, 1, 1), //우상
    //         new Vector3(1, 1, -1), //우하
    //         new Vector3(-1, 1, -1), //좌하

    //         //아래
    //         new Vector3(-1, -1, -1), //좌상
    //         new Vector3(1, -1, -1), //우상
    //         new Vector3(1, -1, 1), //우하
    //         new Vector3(-1, -1, 1), //좌하
    //     };

    //     triangles = new int[]
    //     {
    //         //앞
    //         0, 1, 2,
    //         2, 3, 0,

    //         //왼
    //         4, 5, 6,
    //         6, 7, 4,

    //         //뒤
    //         8, 9, 10,
    //         10, 11, 8,

    //         //오
    //         12, 13, 14,
    //         14, 15, 12,

    //         //위
    //         16, 17, 18,
    //         18, 19, 16,

    //         //아래
    //         20, 21, 22,
    //         22, 23, 20
    //     };
    // }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = getData.vertices;
        mesh.triangles = getData.triangles;
        mesh.RecalculateNormals();
    }
}
