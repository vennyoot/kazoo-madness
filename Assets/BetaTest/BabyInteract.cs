using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyInteract : Interaction
{
    public bool active = false;

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
            item.GetComponent<ObjectDisplay>().TapToDestroy();
        }
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
