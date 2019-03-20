using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    MeshFilter meshFilter;
    Mesh mesh;
    Material material;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            //앞
            new Vector3(-1, 1, -1), //좌상
            new Vector3(1, 1, -1), //우상
            new Vector3(1, -1, -1), //우하
            new Vector3(-1, -1, -1), //좌하

            //왼
            new Vector3(1, 1, -1), //좌상
            new Vector3(1, 1, 1), //우상
            new Vector3(1, -1, 1), //우하
            new Vector3(1, -1, -1), //좌하

            //뒤
            new Vector3(1, 1, 1), //좌상
            new Vector3(-1, 1, 1), //우상
            new Vector3(-1, -1, 1), //우하
            new Vector3(1, -1, 1), //좌하

            //오
            new Vector3(-1, 1, 1), //좌상
            new Vector3(-1, 1, -1), //우상
            new Vector3(-1, -1, -1), //우하
            new Vector3(-1, -1, 1), //좌하

            //위
            new Vector3(-1, 1, 1), //좌상
            new Vector3(1, 1, 1), //우상
            new Vector3(1, 1, -1), //우하
            new Vector3(-1, 1, -1), //좌하

            //아래
            new Vector3(-1, -1, -1), //좌상
            new Vector3(1, -1, -1), //우상
            new Vector3(1, -1, 1), //우하
            new Vector3(-1, -1, 1), //좌하
        };

        triangles = new int[]
        {
            //앞
            0, 1, 2,
            2, 3, 0,

            //왼
            4, 5, 6,
            6, 7, 4,

            //뒤
            8, 9, 10,
            10, 11, 8,

            //오
            12, 13, 14,
            14, 15, 12,

            //위
            16, 17, 18,
            18, 19, 16,

            //아래
            20, 21, 22,
            22, 23, 20
        };

        Vector2[] uvs = new Vector2[]
       {
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0),
       };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.bounds = new Bounds(Vector3.zero, new Vector3(1, 2, 1));
        mesh.RecalculateNormals();
    }
}
