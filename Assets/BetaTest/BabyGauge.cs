using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGauge : Gauge
{
    private void Start()
    {
        startFill = 0;
    }

    protected override void AnythingElse()
    {
        rect.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position);// + (Vector3.up * offset));
    }
}
