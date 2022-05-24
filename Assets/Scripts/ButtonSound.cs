using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private AudioSource _audioSource;
    GameObject[] others;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        others = GameObject.FindGameObjectsWithTag("buttonsound");

        foreach (GameObject sound in others)
        {
            if (sound != this.gameObject)
            {
                Destroy(sound);
            }

        }

        _audioSource = GetComponent<AudioSource>();

    }

}
