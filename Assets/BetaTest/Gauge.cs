using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class Gauge : MonoBehaviour
{
    public float startFill = 0;
    public float percent = 0f;
    public float increment = 5;

    public bool full = false;
    public bool empty = false;

    float prev = 0f;
    bool update = false;
    float lerpPercent = 0f;

    public Image meter;
    public RectTransform rect;
    //public GameObject source;

    private void Awake()
    {
        meter = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        //source = transform.parent.parent.gameObject;
    }

    private void Update()
    {
        if (lerpPercent < 1 && update == true)
        {
            lerpPercent += 1 / 10f;
        }
        else
        {
            update = false;
        }

        UpdateDisplay();
        AnythingElse();
    }

    protected abstract void AnythingElse();

    protected virtual void UpdateDisplay()
    {
        meter.fillAmount = Mathf.Lerp(prev, percent, lerpPercent);
        //10, 221, 0
        //133, 1, 23
        meter.color = new Color(Mathf.Lerp(133f/255, 10f / 255,percent),
            Mathf.Lerp( 1f/255, 221f / 255, percent),
            Mathf.Lerp(23f/255, 0f, percent));
    }

    public virtual void Add(float magnitude)
    {
        prev = percent;
        percent += increment / 100f * (magnitude * 20);
        lerpPercent = 0f;
        update = true;

        if (percent > 1)
        {
            percent = 1;
        }
    }
    public virtual void Sub(float magnitude)
    {
        prev = percent;
        percent -= increment / 100f * (magnitude * 20);
        lerpPercent = 0f;
        update = true;

        if (percent < 0.0001)
        {
            percent = 0;
        }
    }

}
