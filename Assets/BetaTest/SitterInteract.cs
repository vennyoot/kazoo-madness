using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitterInteract : Interaction
{
    protected override void InteractInput()
    {
        if (InputHandle.GetSitterInteractKey())
        {
            Debug.Log("Interacting...");
            CheckInteract();
        }
    }
    protected override void Interact(RaycastHit2D hit)
    {
        /*if (hit.transform.gameObject.GetComponent<Interactable>().cleanliness != 1f)
        {
            cleanSpeed = hit.transform.gameObject.GetComponent<Interactable>().cooldown * cleanMultiplier;
            Clean(hit);
            //hit.transform.gameObject.GetComponent<Interactable>().Clean(hit);
        }

        if (hit.transform.gameObject.GetComponent<Bath>())
        {

        }*/
    }
}
