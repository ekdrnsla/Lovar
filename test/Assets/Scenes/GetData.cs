using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GetData : MonoBehaviour
{
    Vector3 vector;

    List<Vector3> vectorList;
    List<Vector3> nearVectorList;
    List<Vector3> sortedVectorList;
    List<Vector3> GapSortedVectorList;
    // List<Vector3> BorderVectorList;
    // List<Vector3> InnerVectorList;
    // List<Vector3>[] BorderVectorList;
    // List<Vector3>[] InnerVectorList;
    List<Vector3> finalVectorList;
    List<int>[] borderAndInnerIndex;

    int shapeWidth = 20;
    int shapeHeight;
    // int[] borderIndex;

    int[] maxBorder; //ULDR
    // float[] maxBorder;
    // int leftVector, rightVector;

    // List<Vector3> getVertexList;
    // List<int> getTriangleList;

    public Vector3[] vertices;
    public int[] triangles;

    public GetData()
    {
        vectorList = new List<Vector3>();
        nearVectorList = new List<Vector3>();
        sortedVectorList = new List<Vector3>();
        GapSortedVectorList = new List<Vector3>();
        // BorderVectorList = new List<Vector3>[4] { new List<Vector3>(), new List<Vector3>(), new List<Vector3>(), new List<Vector3>() };
        // InnerVectorList = new List<Vector3>[4] { new List<Vector3>(), new List<Vector3>(), new List<Vector3>(), new List<Vector3>() };
        borderAndInnerIndex = new List<int>[4] { new List<int>(), new List<int>(), new List<int>(), new List<int>() }; //0:outline 1:innerline
        finalVectorList = new List<Vector3>();

        // borderIndex = new int[4] {0, 0, 0, 0};
        // maxBorder = new float[4];
        getData();
    }

    public void getData()
    {
        string getFile = File.ReadAllText("Assets/Scenes/data.txt");
        string[] data = getFile.Split(char.Parse(","));

        shapeHeight = data.Length / shapeWidth;
        for (int i = 0; i < data.Length; i++)
        {
            // if (i != 0 && data[i - 1] != data[i] && data[i] == "1" || i != data.Length - 1 && data[i] != data[i + 1] && data[i] == "1")
            //     AddVector(i % shapeWidth, i / shapeWidth);
            // else if (i % width == width - 1)
            // outlineVectorList.Add(vectorList[leftVector]);
            // outlineVectorList.Add(vectorList[rightVector]);

            if (data[i] == "1")
                AddVector(i % shapeWidth, i / shapeWidth);

        }

        getSortedVectorList();


        // setWall();
        // AddVector(0, 0);
        // AddVector(0, shapeHeight - 1);
        // AddVector(shapeHeight - 1, shapeHeight - 1);
        // AddVector(shapeHeight - 1, 0);

        // for (int i = 0; i < sortedVectorList.Count; i++) Debug.Log(sortedVectorList[i]);



        getGapSortedVectorList();

        getMaxBorder();

        // Vector3 previousV;
        // Vector3 currentV;
        // for (int i = 1; i < GapSortedVectorList.Count; i++)
        // {
        //     previousV = GapSortedVectorList[i - 1];
        //     currentV = GapSortedVectorList[i];
        //     if (previousV.x < currentV.x && previousV.y > currentV.y || previousV.x < currentV.x && previousV.y < currentV.y) BorderVectorList[i] = GapSortedVectorList[i];
        //     else InnerVectorList[i] = GapSortedVectorList[i];
        // }

        // for (int i = 0; i < GapSortedVectorList.Count; i++) Debug.Log(GapSortedVectorList[i]);

        // int baseIndex = 0;
        // Vector3 baseVector = GapSortedVectorList[baseIndex];

        getBorderAndInnerIndex();
        // sortIndexList.Add(0);
        // Vector3 previousVector;
        // Vector3 currentVector;
        // for (int i = 1; i < GapSortedVectorList.Count; i++)
        // {
        //     previousVector = GapSortedVectorList[sortIndexList.Count - 1];
        //     currentVector = GapSortedVectorList[i];
        //     if (previousVector.x > currentVector.x && previousVector.y < currentVector.y) sortIndexList.Add(i);
        // }

        // for (int i = sortIndexList.Count - 1; i < GapSortedVectorList.Count; i++)
        // {
        //     previousVector = GapSortedVectorList[sortIndexList.Count - 1];
        //     currentVector = GapSortedVectorList[i];
        //     if (previousVector.x > currentVector.x && previousVector.y < currentVector.y) sortIndexList.Add(i);
        // }

        // for (int i = 0; i < GapSortedVectorList.Count; i++) Debug.Log(GapSortedVectorList[i]);
        // for(int i = 0; i < sortIndexList.Count; i++) Debug.Log(sortIndexList[i]);
        // for (int i = 0; i < sortIndexList.Count; i++) Debug.Log(sortIndexList[i]);


        // float lastX = 0, lastY = 0;
        // for (int i = 0; i < sortedVectorList.Count; i++)
        // {
        //     if (lastX < sortedVectorList[i].x && lastY < sortedVectorList[i].y)
        //         sortedBorderVectorList.Add(sortedVectorList[i]);
        //     // for (int j = shapeWidth / 2; j > 0; j--)
        //     // {

        //     // }
        //     lastX = sortedVectorList[i].x;
        //     lastY = sortedVectorList[i].y;
        // }

        // for (int i = 0; i < sortedBorderVectorList.Count; i++) Debug.Log(sortedBorderVectorList[i]);







        // bool flag = true;
        // for (int i = 0; i < vectorList.Count; i++)
        // {
        //     if (vectorList[i].x < shapeWidth / 2 && vectorList[i].y < shapeWidth / 2)
        //         // if (flag)
        //             borderVectorList.Add(vectorList[i]);
        // }

        // for (int i = 0; i < vectorList.Count; i++)
        // {
        //     if (vectorList[i].x < shapeWidth / 2 && vectorList[i].y >= shapeWidth / 2)
        //         borderVectorList.Add(vectorList[i]);
        // }

        // for (int i = 0; i < vectorList.Count; i++)
        // {
        //     if (vectorList[i].x >= shapeWidth / 2 && vectorList[i].y >= shapeWidth / 2)
        //         borderVectorList.Add(vectorList[i]);
        // }

        // for (int i = 0; i < vectorList.Count; i++)
        // {
        //     if (vectorList[i].x >= shapeWidth / 2 && vectorList[i].y < shapeWidth / 2)
        //         borderVectorList.Add(vectorList[i]);
        // }







        // for (int i = 0; i < data.Length; i++)
        // {
        //     if (i != 0 && data[i - 1] != data[i] && data[i] == "1" || i != data.Length - 1 && data[i] != data[i + 1] && data[i] == "1")
        //         AddVector(i % 10, i / 10);
        // }

        // if (vectorList.Count % 3 != 0)
        // {
        //     if (vectorList.Count % 3 == 1) vectorList.RemoveAt(index: vectorList.Count - 1);
        //     else vectorList.RemoveRange(index: vectorList.Count - 2, count: 2);
        // }

        if (vectorList.Count < 2) return;

        getTriangle();

        // vertices = GapSortedVectorList.ToArray();
        // triangles = new int[(GapSortedVectorList.Count - 2) * 3];

        // for (int i = 0; i < vertices.Length - 2; i++)
        // {
        //     if ()
        // }







        // vertices = sortedVectorList.ToArray();
        // triangles = new int[(sortedVectorList.Count - 2) * 3];

        // for (int i = 0; i < vertices.Length - 2; i++)
        // {

        // if (i % 2 == 0)
        // {
        //     // CW
        //     // triangles[i + (i * 2)] = i;
        //     // triangles[i + (i * 2) + 1] = i + 1;
        //     // triangles[i + (i * 2) + 2] = i + 2;

        //     // CCW
        //     triangles[i + (i * 2)] = i + 2;
        //     triangles[i + (i * 2) + 1] = i + 1;
        //     triangles[i + (i * 2) + 2] = i;
        // }
        // else
        // {
        //     // CW
        //     // triangles[i + (i * 2)] = i + 2;
        //     // triangles[i + (i * 2) + 1] = i + 1;
        //     // triangles[i + (i * 2) + 2] = i;

        //     // CCW
        //     triangles[i + (i * 2)] = i;
        //     triangles[i + (i * 2) + 1] = i + 1;
        //     triangles[i + (i * 2) + 2] = i + 2;
        // }
        // }
    }

    void getSortedVectorList()
    {
        sortedVectorList.Add(vectorList[0]);
        float currentX = sortedVectorList[sortedVectorList.Count - 1].x;
        float currentY = sortedVectorList[sortedVectorList.Count - 1].y;
        List<int> sortIndexList = new List<int>();
        while (vectorList.Count != sortedVectorList.Count)
        {
            addNearVectorList(currentX, currentY, -1, -1);
            addNearVectorList(currentX, currentY, -1, 0);
            addNearVectorList(currentX, currentY, -1, 1);
            addNearVectorList(currentX, currentY, 0, 1);
            addNearVectorList(currentX, currentY, 1, 1);
            addNearVectorList(currentX, currentY, 1, 0);
            addNearVectorList(currentX, currentY, 1, -1);
            addNearVectorList(currentX, currentY, 0, -1);

            // nearVectorList.RemoveAll(v => v.x == 0 && v.y == 0);

            for (int i = 0; i < 8; i++)
                if (!sortedVectorList.Contains(nearVectorList[i]) && nearVectorList[i].x != 0 && nearVectorList[i].y != 0)
                    sortIndexList.Add(i);

            if (sortIndexList.Count >= 2)
            {
                int one = sortIndexList[0], two = sortIndexList[1];
                if (one == 4 && two == 5 || one == 6 && two == 7 || one == 0 && two == 7 || one == 2 && two == 3 || one == 0 && two == 1)
                    sortIndexList.Reverse();
            }

            sortedVectorList.Add(nearVectorList[sortIndexList[0]]);

            // else if(sortIndex[0] > 0 && sortIndex[0] < 3)

            // while (true)
            // {
            //     if (!sortedVectorList.Contains(nearVectorList[0]) && nearVectorList[0].x != 0 && nearVectorList[0].y != 0)
            //         break;
            //     else if (nearVectorList.Count == 1) break;
            //     else nearVectorList.RemoveAt(0);
            // }

            // if (sortIndexList.Count != 0)

            currentX = sortedVectorList[sortedVectorList.Count - 1].x;
            currentY = sortedVectorList[sortedVectorList.Count - 1].y;
            nearVectorList.Clear();
            sortIndexList.Clear();
        }
    }

    void getGapSortedVectorList()
    {
        for (int i = 0; i < sortedVectorList.Count; i++)
            if (i % 1 == 0) GapSortedVectorList.Add(sortedVectorList[i]);
        // if (i % 2 == 0) GapSortedVectorList.Add(sortedVectorList[i]);
    }

    void getMaxBorder()
    {
        // List<Vector3> sort = new List<Vector3>();
        // sort = GapSortedVectorList;
        // sort.Sort((x, y) => y.x.CompareTo(x.x));
        // maxBorder[1] = sort[1].x;

        // Debug.Log(maxBorder[1]);
        // Vector3 previousVector = sortedVectorList[sortedVectorList.Count - 2];
        // Vector3 currentVector = sortedVectorList[sortedVectorList.Count - 1];
        // if (previousVector.y >= currentVector.y) borderMax[0] = currentVector.y;
        // else if (previousVector.x >= currentVector.x) borderMax[1] = currentVector.x;
        // else if (previousVector.y <= currentVector.y) borderMax[2] = currentVector.y;
        // else if (previousVector.x <= currentVector.x) borderMax[3] = currentVector.x;
        // for (int i = 0; i < borderMax.Length; i++) Debug.Log(borderMax[i]);
    }

    void addNearVectorList(float currentX, float currentY, int x, int y)
    {
        nearVectorList.Add(vectorList.Find(v => v.x == currentX + x && v.y == currentY + y));
    }

    void getBorderAndInnerIndex()
    {
        // List<int> sortIndexList = new List<int>();
        // sortIndexList.Add(0);
        // Vector3 previousVector;
        // Vector3 currentVector;
        // for (int i = 1; i < GapSortedVectorList.Count; i++)
        // {
        //     previousVector = GapSortedVectorList[sortIndexList.Count - 1];
        //     currentVector = GapSortedVectorList[i];
        //     if (previousVector.x >= currentVector.x && previousVector.y <= currentVector.y) sortIndexList.Add(i);
        // }


        // borderAndInnerIndex[0].Add(0);
        float minX, minY;
        // Vector3 baseVector;
        // Vector3 previousVector;
        // Vector3 currentVector;
        minX = GapSortedVectorList[0].x;
        minY = GapSortedVectorList[0].y;
        for (int i = 0; i < GapSortedVectorList.Count; i++)
        {
            if (GapSortedVectorList[i].x <= minX && GapSortedVectorList[i].y >= minY)
            {
                borderAndInnerIndex[0].Add(i);
                minX = GapSortedVectorList[i].x;
                minY = GapSortedVectorList[i].y;
            }

            // baseVector = GapSortedVectorList[borderAndInnerIndex[0].Count - 1];
            // previousVector = GapSortedVectorList[i - 1];
            // currentVector = GapSortedVectorList[i];
            // if (previousVector.x >= currentVector.x && previousVector.y <= currentVector.y) borderAndInnerIndex[0].Add(i);
            // if (baseVector.x >= currentVector.x && previousVector.x >= currentVector.x && baseVector.y <= currentVector.y && previousVector.y <= currentVector.y) borderAndInnerIndex[0].Add(i);
        }
        // borderAndInnerIndex[0].RemoveAt(borderAndInnerIndex[0].Count - 1);

        for (int i = borderAndInnerIndex[0][borderAndInnerIndex[0].Count - 1]; i < GapSortedVectorList.Count; i++)
        {
            if (GapSortedVectorList[i].x >= minX && GapSortedVectorList[i].y >= minY)
            {
                borderAndInnerIndex[1].Add(i);
                minX = GapSortedVectorList[i].x;
                minY = GapSortedVectorList[i].y;
            }
        }

        for (int i = borderAndInnerIndex[1][borderAndInnerIndex[1].Count - 1]; i < GapSortedVectorList.Count; i++)
        {
            if (GapSortedVectorList[i].x >= minX && GapSortedVectorList[i].y <= minY)
            {
                borderAndInnerIndex[2].Add(i);
                minX = GapSortedVectorList[i].x;
                minY = GapSortedVectorList[i].y;
            }
        }



        // for (int i = borderAndInnerIndex[0][borderAndInnerIndex[0].Count - 1]; i < GapSortedVectorList.Count; i++)
        // {
        //     baseVector = GapSortedVectorList[borderAndInnerIndex[0].Count - 1];
        //     previousVector = GapSortedVectorList[i - 1];
        //     currentVector = GapSortedVectorList[i];
        //     if (baseVector.x <= currentVector.x && previousVector.x <= currentVector.x && baseVector.y <= currentVector.y && previousVector.y <= currentVector.y) borderAndInnerIndex[1].Add(i);
        //     // if (previousVector.x <= currentVector.x && previousVector.y <= currentVector.y) borderAndInnerIndex[1].Add(i);
        // }

        // for (int i = borderAndInnerIndex[1][borderAndInnerIndex[1].Count - 1]; i < GapSortedVectorList.Count; i++)
        // {
        //     previousVector = GapSortedVectorList[borderAndInnerIndex[1].Count];
        //     currentVector = GapSortedVectorList[i];
        //     if (previousVector.x <= currentVector.x && previousVector.y >= currentVector.y) borderAndInnerIndex[2].Add(i);
        // }

        // for (int i = borderAndInnerIndex[2][borderAndInnerIndex[2].Count - 1]; i < GapSortedVectorList.Count; i++)
        // {
        //     previousVector = GapSortedVectorList[borderAndInnerIndex[2].Count];
        //     currentVector = GapSortedVectorList[i];
        //     if (previousVector.x >= currentVector.x && previousVector.y >= currentVector.y) borderAndInnerIndex[3].Add(i);
        // }

        // for (int i = 0; i < borderAndInnerIndex[0].Count; i++) Debug.Log(GapSortedVectorList[borderAndInnerIndex[0][i]]);
        // for (int i = 0; i < borderAndInnerIndex[1].Count; i++) Debug.Log(GapSortedVectorList[borderAndInnerIndex[1][i]]);
        // for (int i = 0; i < borderAndInnerIndex[0].Count; i++) Debug.Log(borderAndInnerIndex[0][i]);
        // for (int i = 0; i < borderAndInnerIndex[0].Count; i++) Debug.Log(GapSortedVectorList[borderAndInnerIndex[0][i]]);

        // int previousInt;
        // int currentInt;
        // for (int i = 1; i < borderAndInnerIndex[0].Count; i++)
        // {
        //     previousInt = borderAndInnerIndex[0][i - 1];
        //     currentInt = borderAndInnerIndex[0][i];
        //     if (currentInt - previousInt != 1) borderAndInnerIndex[1].Add(i);
        // }

        // for (int i = 0; i < borderAndInnerIndex[0].Count; i++) Debug.Log(borderAndInnerIndex[0][i]);
        // for (int i = 0; i < borderAndInnerIndex[1].Count; i++) Debug.Log(borderAndInnerIndex[1][i]);
        for (int i = 0; i < borderAndInnerIndex[2].Count; i++) Debug.Log(borderAndInnerIndex[2][i]);
        // for (int i = 0; i < borderAndInnerIndex[3].Count; i++) Debug.Log(borderAndInnerIndex[3][i]);

        // for(int i = 0 ; i < borderAndInnerIndex[1][0]; i++){

        // }



        // for (int i = 0; i < 2; i++){
        //     for (int j = sortIndexList[i][i]; i < sortIndexList[i].Count; j++)
        //     {
        //         BorderVectorList[0].Add(GapSortedVectorList[sortIndexList[0][j]]);
        //     }
        // }


        for (int i = 0; i < borderAndInnerIndex[0].Count; i++)
        {
            finalVectorList.Add(GapSortedVectorList[borderAndInnerIndex[0][i]]);
        }
    }

    void getTriangle()
    {
        // vertices = GapSortedVectorList.ToArray();
        // vertices = finalVectorList.ToArray();
        // triangles = new int[(sortedVectorList.Count - 2) * 3];


        // triangles[0] = 0;
        // triangles[1] = 1;
        // triangles[2] = 2;
        // triangles[3] = 0;
        // triangles[4] = 2;
        // triangles[5] = 3;


        // for (int i = 0; i < triangles.Length; i+=3)
        // {
        //     triangles[i] = borderAndInnerIndex[0][0];
        //     triangles[i + 1] = borderAndInnerIndex[0][i + 1];
        //     triangles[i + 2] = borderAndInnerIndex[0][i + 2];
        // }


        // vertices = sortedVectorList.ToArray();
        // triangles = new int[(sortedVectorList.Count - 2) * 3];

        // for (int i = 0; i < vertices.Length - 2; i++)
        // {

        // if (i % 2 == 0)
        // {
        //     // CW
        //     // triangles[i + (i * 2)] = i;
        //     // triangles[i + (i * 2) + 1] = i + 1;
        //     // triangles[i + (i * 2) + 2] = i + 2;

        //     // CCW
        //     triangles[i + (i * 2)] = i + 2;
        //     triangles[i + (i * 2) + 1] = i + 1;
        //     triangles[i + (i * 2) + 2] = i;
        // }
        // else
        // {
        //     // CW
        //     // triangles[i + (i * 2)] = i + 2;
        //     // triangles[i + (i * 2) + 1] = i + 1;
        //     // triangles[i + (i * 2) + 2] = i;

        //     // CCW
        //     triangles[i + (i * 2)] = i;
        //     triangles[i + (i * 2) + 1] = i + 1;
        //     triangles[i + (i * 2) + 2] = i + 2;
        // }
        // }
    }

    // void setWall()
    // {
    //     AddVector(0, 0);
    //     AddVector(0, shapeHeight - 1);
    //     AddVector(shapeHeight - 1, shapeHeight - 1);
    //     AddVector(shapeHeight - 1, 0);
    // }

    void AddVector(int x, int y)
    {
        vector.x = x;
        vector.y = y;
        vectorList.Add(vector);
    }
}
