using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSitter : AudioBase
{
    public AudioClip onFix;
    public AudioClip onWin;

    void OnFix()
    {
        PlayAudio(onFix);
    }

    void OnWin()
    {
        PlayAudio(onWin);
    }
}
