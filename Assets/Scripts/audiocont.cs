using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocont : MonoBehaviour
{
    void Start()
    {
        CheckAudioSources();
    }

    void CheckAudioSources()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            Debug.Log("Audio Source bulundu: " + audioSource.gameObject.name);
        }
    }
}
