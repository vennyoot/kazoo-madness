using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplay : MonoBehaviour
{
    public ObjectData data;
    public CleanGauge meter;

    public float increment = 0;

    private void Awake()
    {
        meter = GetComponentInChildren<CleanGauge>();
        increment = 1 / data.tapsToDestroy;

    }

    public void TapToClean()
    {
        meter.AddWithEvent(increment);
    }

    public void TapToDestroy()
    {
        meter.SubWithEvent(increment);
    }
}
