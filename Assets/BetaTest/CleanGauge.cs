using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanGauge : Gauge
{
    public bool dirty = false;
    public UnityEvent onUniqueEmpty;
    public UnityEvent onUniqueFull;
    public float cooldown = 3;

    public float timer = 0;

    private void Start()
    {
        startFill = 1;
        Add(startFill);
        full = true;
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
