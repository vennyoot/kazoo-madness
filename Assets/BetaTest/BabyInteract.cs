using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyInteract : Interaction
{
    public bool active = false;
    public float multiplier = 1;
    public float maxMultiplier = 2;

    BabyGauge meter;

    // Update is called once per frame
    protected override void InteractInput()
    {
        if (active)
        {
            if (InputHandle.GetBabyInteractKey())
            {
                Debug.Log("Interacting...");
                CheckInteract(LayerMask.GetMask("Interactable"));
            }
        }
    }
    protected override void Interact(Collider2D item, LayerMask layer)
    {
        if (layer == LayerMask.GetMask("Interactable"))
        {
            item.GetComponent<ObjectDisplay>().TapToDestroy(this);
        }
    }

    public void SetActive(bool b)
    {
        active = b;
    }

    public void ResetMultiplier()
    {
        if (meter ==null)
        {
            meter = GetComponentInChildren<BabyGauge>();
        }

        meter.Sub(maxMultiplier);
        multiplier = 1;
    }

    public void AddToMultiplier(float magnitude)
    {
        meter = GetComponentInChildren<BabyGauge>();

        multiplier += magnitude;
        meter.Add(magnitude/(maxMultiplier-1));

        if (multiplier > maxMultiplier)
        {
            multiplier = maxMultiplier;
        }
    }
}
