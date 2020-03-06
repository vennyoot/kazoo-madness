using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioItem : AudioBase
{
    public AudioClip onBreak;
    public AudioClip onClean;

    void OnBreak()
    {
        PlayAudio(onBreak);
    }

    void OnClean()
    {
        PlayAudio(onClean);
    }
}