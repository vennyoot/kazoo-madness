using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWins : AudioBase
{
    public AudioClip onBabyWin;
    public AudioClip onSitterWin;

    void OnBabyWin()
    {
        PlayAudio(onBabyWin);
    }

    void OnSitterWin()
    {
        PlayAudio(onSitterWin);
    }
}
