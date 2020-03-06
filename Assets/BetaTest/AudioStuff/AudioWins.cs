using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWins : AudioBase
{
    public AudioClip onBabyWin;
    public AudioClip onSitterWin;

    private void Start()
    {
        GetComponentInChildren<HouseGauge>().onEmpty.AddListener(OnBabyWin);
        GetComponentInChildren<HouseGauge>().onFull.AddListener(OnSitterWin);

    }

    void OnBabyWin()
    {
        PlayAudio(onBabyWin);
    }

    void OnSitterWin()
    {
        PlayAudio(onSitterWin);
    }
}
