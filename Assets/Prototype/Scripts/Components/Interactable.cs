using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public float cleanliness = 1f;
    public float cooldown = 1f;

    bool emptyInvoke = false;

    public UnityEvent empty;

    Meter meter;

    private void Start()
    {
        meter = GetComponentInChildren<Meter>();
    }

    private void Update()
    {
        //TODO: cleaning cannot be bool, cleaning must be more than one state
        cleanliness = meter.percent;

        /*if (cleanliness <= 0)
        {
            if (!emptyInvoke)
            {
                OnEmpty();
                emptyInvoke = true;
            }
        }*/
    }

    void OnEmpty()
    {
        empty.Invoke();
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
