using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public static string selectedMap;
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
            return;
        }
        else if (_buttonName == "back")
        {
            menu.SetActive(true);
            maps.SetActive(false);
            GameObject.Find("Man in the Wall").GetComponent<Text>().text = "Man in the Wall";
            return;
        }
        else if (_buttonName == "exit")
        {
            Application.Quit();
            return;
        }
        else if (_buttonName == "retry")
        {
            SceneManager.LoadScene(selectedMap);
            return;
        }
        else if (_buttonName == "main")
        {
            SceneManager.LoadScene("Start");
            return;
        }

        SceneManager.LoadScene(_buttonName);
        selectedMap = _buttonName;
    }
}
