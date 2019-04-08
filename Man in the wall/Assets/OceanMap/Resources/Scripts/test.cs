using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    public AudioClip otherClip;
    
    void Start() {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = otherClip;
    
        audio.Play();
    }
}