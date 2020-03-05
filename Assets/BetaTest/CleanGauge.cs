using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanGauge : Gauge
{
    public bool dirty = false;
    public UnityEvent onUniqueEmpty;
    public UnityEvent onUniqueFull;

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

            //if dirty already, dont give bonus
            if (dirty)
            {
                Debug.Log("I wasn't fully cleaned.");
            }
            else
            {
                onUniqueEmpty.Invoke();
                dirty = true;
            }
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

            //if clean already, dont give bonus
            if (!dirty)
            {
                Debug.Log("I wasn't fully dirtied.");
            }
            else
            {
                onUniqueFull.Invoke();
                dirty = false;
            }
        }
    }
}
