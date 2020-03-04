using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Meter : MonoBehaviour
{
    Image meter;
    float prev = 0f;
    public float percent = 0f;
    float lerpPercent = 0f;
    bool update = false;
    float offset = 0.7f;
    public float startFill = 0;

    public HouseMeter cleanHouseMeter;
    public HouseMeter dirtyHouseMeter;

    public float incToHouseMeter = 0.1f;
    bool broke = false;

    RectTransform rect;
    public UnityEvent onEmpty;
    public UnityEvent onFull;

    [SerializeField]
    float increment = 5;

    private void Awake()
    {
        meter = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        cleanHouseMeter = GameObject.Find("cleanHouse").GetComponent<HouseMeter>();
        dirtyHouseMeter = GameObject.Find("dirtyHouse").GetComponent<HouseMeter>();

        Add(startFill);
    }

    void Update()
    {
        rect.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position);// + (Vector3.up * offset));

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
        percent += increment / 100f * (magnitude * 21);//12);
        lerpPercent = 0f;
        update = true;

        if (percent > 1)
        {
            percent = 1;
        }

        if (percent ==1 && broke)
        {
            cleanHouseMeter.AddHouse(incToHouseMeter);
        }
        if (percent == 1)
        {
            broke = true;
        }
    }

    public void Sub(float magnitude)
    {
        prev = percent;
        percent -= increment / 100f * (magnitude * 21);
        lerpPercent = 0f;
        update = true;

        if (percent < 0)
        {
            percent = 0;
        }

        if (percent ==0)
        {
            dirtyHouseMeter.AddHouse(incToHouseMeter);
        }
    }

    public void Reset()
    {
        percent = 0;
    }
}
