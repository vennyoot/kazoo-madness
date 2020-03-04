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
                CheckInteract();
            }
        }
    }
    protected override void Interact(Collider2D item)
    {
            /*if (hit.transform.gameObject.GetComponent<Interactable>().cleanliness <= 1 && hit.transform.gameObject.GetComponent<Interactable>().cleanliness > 0)
            {
                Babies[currentIndex].GetComponent<BabyData>().Mess(hit, prevDir, interactRange);
            }*/
        
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
