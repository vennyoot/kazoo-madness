using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioItem : AudioBase
{
    public AudioClip onBreak;
    public AudioClip onClean;

    public void OnBreak()
    {
        PlayAudio(onBreak);
    }

    public void OnClean()
    {
        PlayAudio(onClean);
    }
}