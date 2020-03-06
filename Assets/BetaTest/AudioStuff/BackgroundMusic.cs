using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : AudioBase
{
    public AudioClip backgroundMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayAudio(backgroundMusic);
    }
}
