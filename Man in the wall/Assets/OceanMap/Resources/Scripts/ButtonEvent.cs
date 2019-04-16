using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    GameObject menu;
    GameObject maps;

    public string playButtonSound;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        if (menu = GameObject.Find("menu"))
            menu.SetActive(true);
        if (maps = GameObject.Find("maps"))
            maps.SetActive(false);

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectButton(string _buttonName)
    {
        audioManager.Play(playButtonSound);

        if (_buttonName == "play")
        {
            menu.SetActive(false);
            maps.SetActive(true);
            GameObject.Find("Man in the Wall").GetComponent<Text>().text = "Select Map";
            GameObject.Find("Man in the Wall").transform.Translate(0, 80, 0);
        }
        else if (_buttonName == "back")
        {
            menu.SetActive(true);
            maps.SetActive(false);
            GameObject.Find("Man in the Wall").GetComponent<Text>().text = "Man in the Wall";
            GameObject.Find("Man in the Wall").transform.Translate(0, -80, 0);
        }
        else if (_buttonName == "exit")
        {
            Application.Quit();
        }
        else if (_buttonName == "retry")
        {
            SceneManager.LoadScene(RetryMapName.retryMapName);
        }
        else if (_buttonName == "main")
        {
            SceneManager.LoadScene("Start");
        }
        else
        {
            SceneManager.LoadScene(_buttonName);
            RetryMapName.retryMapName = _buttonName;
        }
    }
}
