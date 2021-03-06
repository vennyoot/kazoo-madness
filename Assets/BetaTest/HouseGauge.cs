﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HouseGauge : Gauge
{
    public UnityEvent onEmpty;
    public UnityEvent onFull;

    private void Awake()
    {
        meter = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        startFill = 0.999999f;
        Add(startFill);
    }

    protected override void AnythingElse()
    {
        
    }

    public override void Sub(float magnitude)
    {
        base.Sub(magnitude);

        if (percent == 0)
        {
            Debug.Log("House meter empty?");
            onEmpty.Invoke();
        }
    }

    public override void Add(float magnitude)
    {
        base.Add(magnitude);

        if (percent == 1)
        {
            onFull.Invoke();
        }
    }
}
