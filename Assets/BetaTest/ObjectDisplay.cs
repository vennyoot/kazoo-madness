using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplay : MonoBehaviour
{
    public ObjectData data;
    public CleanGauge meter;
    public SpriteRenderer sprite;
    public BabyInteract lastDestroyer;

    public float increment = 0;

    private void Awake()
    {
        meter = GetComponentInChildren<CleanGauge>();
        sprite = GetComponent<SpriteRenderer>();
        increment = 1 / data.tapsToDestroy;
    }

    private void Start()
    {
        meter.onUniqueEmpty.AddListener(onDirty);
        meter.onUniqueFull.AddListener(onClean);
    }

    public void TapToClean()
    {
        meter.AddWithEvent(increment);
    }

    public void TapToDestroy(BabyInteract source)
    {
        lastDestroyer = source;
        meter.SubWithEvent(increment * source.multiplier);
    }

    public void onDirty()
    {
        sprite.sprite = data.dirty;

        GetComponent<AudioItem>().OnBreak();
        //give score worth to house meter
        FindObjectOfType<HouseGauge>().Sub(data.scoreWorth * 0.1f);

        //give baby multiplier, multiplier max of 5x
        if (lastDestroyer != null)
        {
            lastDestroyer.AddToMultiplier(data.giveBabyDirt);
        }
    }

    void onClean()
    {
        sprite.sprite = data.clean;
        GetComponent<AudioItem>().OnClean();

        //give score worth to house meter
        FindObjectOfType<HouseGauge>().Add(data.scoreWorth * 0.15f);
    }
}
