using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseGauge : Gauge
{
    public UnityEvent onEmpty;
    public UnityEvent onFull;

    private void Start()
    {
        startFill = 1;
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
            onEmpty.Invoke();
        }
    }
}
