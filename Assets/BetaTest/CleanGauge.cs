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
        if (percent != 0)
        {
            Sub(magnitude);
            Debug.Log(percent);
            full = false;
        }

        if (percent == 0 && !empty)
        {
            //if empty, push house meter to dirty
            Debug.Log("I'm empty!");
            empty = true;
        }
    }

    public void AddWithEvent(float magnitude)
    {
        if (percent != 1)
        {
            Add(magnitude);
            Debug.Log(percent);
            empty = false;
        }

        if (percent == 1 && !full)
        {
            //if full, push house meter to clean
            Debug.Log("I'm full!");
            full = true;
        }
    }
}
