using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioSource _audioSourceERROR;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSourceERROR = GameObject.FindGameObjectWithTag("errorsound").GetComponent<AudioSource>();
    }

    public void PlaySoundUpgrade()
    {
        _audioSource.Play();
    }
    public void PlayError()
    {
        _audioSourceERROR.Play();
    }

}
