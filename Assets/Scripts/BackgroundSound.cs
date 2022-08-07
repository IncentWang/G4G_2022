using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{

    public List<AudioClip> backgroundSounds;
    int index = 0;
    void Start()
    {
        StartCoroutine("PlaySound");
    }

    IEnumerator PlaySound()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(backgroundSounds[index], transform.position);
            yield return new WaitForSeconds(150);
            index++;
            if (index > backgroundSounds.Count) 
            {
                index = 0;
            }
        }
    }
}
