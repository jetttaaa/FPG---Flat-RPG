using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        Play();
    }

    public void Play()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
    public void Stop()
    {
        _audioSource.Stop();
    }


}
