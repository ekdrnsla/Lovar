using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6 };
        List<int> b = new List<int>() { 1, 2, 3};
    }

    // Update is called once per frame
    void Update()
    {

    }

      public Material mat;
    void OnPostRender() {
        if (!mat) {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.QUADS);
        GL.Color(Color.red);
        GL.Vertex3(0, 0.5F, 0);
        GL.Vertex3(0.5F, 1, 0);
        GL.Vertex3(1, 0.5F, 0);
        GL.Vertex3(0.5F, 0, 0);
        GL.Color(Color.cyan);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(0, 0.25F, 0);
        GL.Vertex3(0.25F, 0.25F, 0);
        GL.Vertex3(0.25F, 0, 0);
        GL.End();
        GL.PopMatrix();
    }
}
