using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateWall : MonoBehaviour
{
    public GameObject obj;
    public float scale;
    string[] values;
    GameObject positionObject;

    void Start()
    {
        positionObject = new GameObject("_position");
        Parse();
    }

    public void Parse()
    {
        TextAsset data = Resources.Load("Data/data") as TextAsset;
        StringReader sr = new StringReader(data.text);

        int y = 0;

        // 먼저 한줄을 읽는다. 
        string source = sr.ReadLine();
        // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )
        while (source != null)
        {

            values = source.Split(',');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.

            for (int x = 0; x < values.Length; x++)
            {
                if (values[x] != null && values[x] == "0")
                {
                    var Object = Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);
                    Object.transform.SetParent(positionObject.transform);
                }
            }


            if (values.Length == 0)
            {
                sr.Close();
                return;
            }
            source = sr.ReadLine();    // 한줄 읽는다.
            y--;
        }
        positionObject.transform.SetParent(transform);
        positionObject.transform.position = new Vector3(-values.Length / 2 * scale, transform.position.y + -y * scale, transform.position.z);
        positionObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {

    }
}