using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool clean = true;
    public float cooldown = 1f;

    Meter meter;

    private void Start()
    {
        meter = GetComponentInChildren<Meter>();
    }

    private void Update()
    {

        //TODO: cleaning cannot be bool, cleaning must be more than one state
        if (meter.percent != 1)
        {
            clean = false;
        }
        else
        {
            clean = true;
        }
    }

    /*public void Clean(RaycastHit2D source)
    {
        //tapping
        StartCoroutine(Cleaning());
    }

    public void Mess(RaycastHit2D source)
    {
        //tapping
        StartCoroutine(Messing());
    }

    IEnumerator Cleaning()
    {
        yield return new WaitForSeconds(cooldown);
        Debug.Log("cleaning");
        StartCoroutine(Cleaning());
    }

    IEnumerator Messing()
    {
        yield return new WaitForSeconds(cooldown);
        Debug.Log("messing");
        StartCoroutine(Messing());
    }*/
}
