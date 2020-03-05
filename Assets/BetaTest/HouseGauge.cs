using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseGauge : Gauge
{
    UnityEvent onEmpty;

    private void Start()
    {
        startFill = 1;
        Add(startFill);
    }

    protected override void AnythingElse()
    {
        
    }
}
