using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    AudioSource source;
    public List<AudioClip> backgroundSounds;
    int index = 0;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = backgroundSounds[index];
        source.Play();
        Debug.Log(backgroundSounds.Count);
    }
    private void Update()
    {
        if (!source.isPlaying)
        {
            NextSound();
        }
    }
    void NextSound()
    {
        index++;
        if (index > backgroundSounds.Count - 1)
        {
            index = 0;
        }
        source.clip = backgroundSounds[index];
        source.Play();
    }
}
