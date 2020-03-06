using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBase : MonoBehaviour
{

    protected AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        Debug.Log("playing audio " + clip);
        audio.clip = clip;
        audio.Play();
    }

}
