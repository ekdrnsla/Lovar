using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    BGMManager bgm;
    public int track;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        BGMPlay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BGMPlay()
    {
        if (bgm = FindObjectOfType<BGMManager>())
        {
            bgm.Volume(volume);
            bgm.Play(track);
        }
    }
}
