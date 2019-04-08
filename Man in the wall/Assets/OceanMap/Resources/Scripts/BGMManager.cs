using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play(int _track)
    {
        source.clip = clips[_track];
        source.Play();
    }

    public void Volume(float _volume)
    {
        source.volume = _volume;
    }

    public void Stop()
    {
        source.Stop();
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        for (float i = 0; i <= 1; i += 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        for (float i = 1.0f; i >= 0; i -= 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }
}
