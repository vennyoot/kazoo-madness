using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HouseMeter : MonoBehaviour
{
    public HouseMeter other;
    
    Image meter;
    float prev = 0f;
    public float percent = 0f;
    float lerpPercent = 0f;
    bool update = false;
    float offset = 0.7f;
    public float startFill = 0;

    RectTransform rect;
    public UnityEvent onEmpty;
    public UnityEvent onFull;

    [SerializeField]
    float increment = 5;

    private void Awake()
    {
        meter = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        Add(startFill);
    }

    void Update()
    {
        if (lerpPercent < 1 && update == true)
        {
            lerpPercent += 1 / 10f;
        }
        else
        {
            update = false;
        }

        meter.fillAmount = Mathf.Lerp(prev, percent, lerpPercent);
        //Debug.Log(lerpPercent);

    }

    public void Add(float magnitude)
    {
        prev = percent;
        percent += increment / 100f * (magnitude * 20);//12);
        lerpPercent = 0f;
        update = true;

        if (percent > 1)
        {
            percent = 1;
        }
    }

    public void Sub(float magnitude)
    {
        prev = percent;
        percent -= increment / 100f * (magnitude * 20);
        lerpPercent = 0f;
        update = true;

        if (percent < 0)
        {
            percent = 0;
        }
    }

    public void Reset()
    {
        percent = 0;
    }

    public void AddHouse(float magnitude)
    {
        Add(magnitude);
        other.Sub(magnitude);
    }
}
