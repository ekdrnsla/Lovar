using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    string[] setText = new string[]{
            "준비가 되면",
            "버튼을 눌러주세요"
            };
    Text messageText;
    bool isCreateWall = false;
    Color alpahColor;
    CreateWall createWallObj;
    IEnumerator readyMessageCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        messageText = GameObject.Find("message").GetComponentInChildren<Text>();
        alpahColor = new Color(0, 0, 0, 0);
        messageText.color = alpahColor;
        createWallObj = FindObjectOfType<CreateWall>();

        readyMessageCoroutine = readyMessage(1);
        StartCoroutine(readyMessageCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if (createWallObj._wallObject && !isCreateWall)
        {
            messageText.text = "";
            StopCoroutine(readyMessageCoroutine);
            isCreateWall = true;
        }
        else if (!createWallObj._wallObject && isCreateWall)
        {
            StartCoroutine(readyMessageCoroutine);
            isCreateWall = false;
        }
    }

    IEnumerator readyMessage(float _sec)
    {
        while (true)
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
