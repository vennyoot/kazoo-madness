using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGauge : Gauge
{
    private void Start()
    {
        startFill = 1;
        Add(startFill);
    }

    protected override void AnythingElse()
    {
        
    }
}
