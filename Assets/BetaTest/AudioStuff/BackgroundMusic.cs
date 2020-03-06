using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : AudioBase
{
    public AudioClip backgroundMusic;
    private void Start()
    {
        audio.loop = true;
        PlayAudio(backgroundMusic);
    }
}
