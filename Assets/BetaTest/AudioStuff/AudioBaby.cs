using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBaby : AudioBase
{
    public AudioClip onBreak;
    public AudioClip onWin;
    public AudioClip onSwitch;

    void OnBreak()
    {
        PlayAudio(onBreak);
    }

    void OnWin()
    {
        PlayAudio(onWin);
    }

    void OnSwitch()
    {
        PlayAudio(onSwitch);
    }
}
