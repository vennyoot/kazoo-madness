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
            CheckInteract(LayerMask.GetMask("Interactable"));
        }

        if (InputHandle.GetSitterPickUpKey())
        {
            Debug.Log("Picking up...");
            CheckInteract(LayerMask.GetMask("Pickupable"));
        }
    }
    protected override void Interact(Collider2D hit, LayerMask layer)
    {
        if (layer == LayerMask.GetMask("Interactable"))
        {
            hit.GetComponent<ObjectDisplay>().TapToClean();
        }

        if (layer == LayerMask.GetMask("Pickupable"))
        {
            //pick up child
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //place in bath if have picked up child
    }
}
