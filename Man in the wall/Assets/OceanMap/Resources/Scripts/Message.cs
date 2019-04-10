using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    string[] setText = new string[2]{
            "곧 벽이 생성됩니다",
            "준비하세요"
            };
    Text messageText;
    bool isCreateWall = false;
    Color alpahColor;

    // Start is called before the first frame update
    void Start()
    {
        messageText = GameObject.Find("message").GetComponentInChildren<Text>();
        alpahColor = new Color(0, 0, 0, 0);
        messageText.color = alpahColor;

        StartCoroutine(readyMessage(1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator readyMessage(float _sec)
    {
        while (!isCreateWall)
        {
            for (int i = 0; i < setText.Length; i++)
            {
                messageText.text = setText[i];
                StartCoroutine(showText(_sec / 2));
                yield return new WaitForSeconds(_sec);
                StartCoroutine(hideText(_sec / 2));
                yield return new WaitForSeconds(_sec);
            }
        }
    }

    IEnumerator hideText(float _sec)
    {
        while (alpahColor.a > 0)
        {
            alpahColor.a -= 0.05f;
            messageText.color = alpahColor;
            yield return new WaitForSeconds(_sec * Time.deltaTime);
        }
    }

    IEnumerator showText(float _sec)
    {
        while (alpahColor.a < 1)
        {
            alpahColor.a += 0.05f;
            messageText.color = alpahColor;
            yield return new WaitForSeconds(_sec * Time.deltaTime);
        }
    }
}
