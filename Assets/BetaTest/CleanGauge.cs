using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanGauge : Gauge
{
    private void Start()
    {
        startFill = 1;
        Add(startFill);
    }

    public void SubWithEvent(float magnitude)
    {
        Sub(magnitude);

        if (percent == 0)
        {
            //if empty, push house meter to dirty
        }
    }

    public void AddWithEvent(float magnitude)
    {
        Add(magnitude);

        if (percent == 1)
        {
            //if full, push house meter to clean
        }
    }
}
