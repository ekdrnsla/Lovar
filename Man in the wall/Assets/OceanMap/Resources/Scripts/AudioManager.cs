using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    AudioSource source;
    public float volume;
    public bool loop;

    public void Source(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Volume()
    {
        source.volume = volume;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void Loop(bool _bool)
    {
        source.loop = _bool;
    }
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("Track " + i + " : " + sounds[i].name);
            sounds[i].Source(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void Loop(string _name, bool _bool)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Loop(_bool);
                return;
            }
        }
    }
    
    public void Volume(string _name, float _volume)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].volume = _volume; 
                sounds[i].Volume();
                return;
            }
        }
    }
}
