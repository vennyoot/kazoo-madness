﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CleanGauge : Gauge
{
    public bool startDirty = false;
    public float cooldown = 3;

    bool dirty = false;
    public UnityEvent onUniqueEmpty;
    public UnityEvent onUniqueFull;

    float timer = 0;

    private void Start()
    {
        meter = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        if (!startDirty)
        {
            startFill = 1;
            Add(startFill);
            full = true;
        }
        else
        {
            dirty = true;
            empty = true;
            transform.parent.parent.GetComponent<ObjectDisplay>().onDirty();
        }
    }

    protected override void AnythingElse()
    {
        rect.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position);// + (Vector3.up * offset));

        timer += Time.deltaTime;

        if (timer > cooldown)
        {
            if (dirty && !empty)
            {
                Sub(1);
                Debug.Log("Recovering dirt");
                empty = true;
            }
            
            if (!dirty && !full)
            {
                Add(1);
                Debug.Log("Recovering clean");
                full = true;
            }
        }
    }

    public void SubWithEvent(float magnitude)
    {
        if (percent != 0)
        {
            Sub(magnitude);
            Debug.Log(percent);
            timer = 0;
            full = false;
        }

        if (percent == 0 && !empty)
        {
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
            timer = 0;
            empty = false;
        }

        if (percent == 1 && !full)
        {
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
