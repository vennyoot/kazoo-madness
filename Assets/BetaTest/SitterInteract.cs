using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitterInteract : Interaction
{
    public GameObject child;

    protected override void InteractInput()
    {
        if (InputHandle.GetSitterInteractKey())
        {
            Debug.Log("Interacting...");
            CheckInteract(LayerMask.GetMask("Interactable"));
        }

        if (InputHandle.GetSitterPickUpKey())
        {
            if (child == null)
            {
                Debug.Log("Picking up...");
                CheckInteract(LayerMask.GetMask("Pickupable"));
            }
            else
            {
                //drop child
                Drop();
            }
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
            PickUp(hit);
        }
    }

    void PickUp(Collider2D hit)
    {
        child = hit.gameObject;
        child.GetComponent<BabyMove>().grabbed = true;
        child.GetComponent<Collider2D>().enabled = false;
        child.transform.parent = transform;
    }

    void Drop()
    {
        child.transform.parent = null;
        child.GetComponent<BabyMove>().grabbed = false;
        child.GetComponent<Collider2D>().enabled = true;
        child = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (child != null && collision.gameObject.GetComponent<Bath>())
        {
            if (collision.gameObject.GetComponent<Bath>().child == null)
            {
                collision.gameObject.GetComponent<Bath>().BathTime(child);
                child.GetComponent<BabyMove>().grabbed = false;
                child = null;
            }
        }
    }
}
