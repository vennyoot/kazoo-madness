using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : AudioBase
{
    public AudioClip onSwitch;

    public void OnSwitch()
    {
        PlayAudio(onSwitch);
    }
}
