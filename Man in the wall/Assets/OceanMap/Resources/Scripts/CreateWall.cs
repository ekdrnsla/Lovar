using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateWall : MonoBehaviour
{
    public GameObject prefab;
    public string fileName;
    public float scale;
    string[] values;
    public GameObject _wallObject;
    float YPos;

    void Start()
    {
        YPos = GetComponentInParent<Transform>().position.y;
    }

    public bool Parse()
    {
        _wallObject = new GameObject("_wall");

        TextAsset data = Resources.Load("Data/" + fileName) as TextAsset;
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
                    var Object = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
                    Object.transform.SetParent(_wallObject.transform);
                }
            }

            if (values.Length == 0)
            {
                sr.Close();
                return false;
            }
            source = sr.ReadLine();    // 한줄 읽는다.
            y--;
        }
        _wallObject.transform.SetParent(transform);
        _wallObject.transform.position = new Vector3(-values.Length / 2 * scale, -y * scale + YPos, transform.position.z);
        _wallObject.transform.localScale = new Vector3(scale, scale, scale);
        return true;
    }
}