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
    RectTransform rect;
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
    }

    protected virtual void UpdateDisplay()
    {
        rect.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position);// + (Vector3.up * offset));
        meter.fillAmount = Mathf.Lerp(prev, percent, lerpPercent);
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
