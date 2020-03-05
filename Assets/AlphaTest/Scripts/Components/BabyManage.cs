using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyManage : PlayerController
{
    public GameObject[] Babies;

    int currentIndex = 0;  //includes rb

    // Start is called before the first frame update
    void Start()
    {
        if (Babies.Length == 0)
        {
            Debug.LogWarning("No babies found");
        }
        else
        {
            rb = Babies[currentIndex].GetComponent<Rigidbody2D>();
        }
    }

    bool BabiesExist()
    {
        return Babies.Length > 0;
    }

    protected override void Interact(RaycastHit2D hit)
    {
        if (hit.transform.gameObject.GetComponent<Interactable>().cleanliness <= 1 && hit.transform.gameObject.GetComponent<Interactable>().cleanliness > 0)
        {
            Babies[currentIndex].GetComponent<BabyData>().Mess(hit, prevDir, interactRange);
        }
    }

    protected override void InputStuff()
    {
        if (BabiesExist())
        {
            //three things need to happen for baby: interact, move, and switch
            if (InputHandle.GetBabyInteractKey())
            {
                CheckInteract();
            }

            //might remove if tapping to escape
            if (!Babies[currentIndex].GetComponent<BabyData>().grabbed)
            {
                Move(InputHandle.GetBabyMovement());
            }

            if (InputHandle.GetSwitchKey())
            {
                Switch();
            }
        }
    }

    void Switch()
    {
        if (Babies.Length > 0 && currentIndex < Babies.Length)
        {
            if (currentIndex == Babies.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
        }

        rb = Babies[currentIndex].GetComponent<Rigidbody2D>();
        speed = Babies[currentIndex].GetComponent<BabyData>().speed;
    }
}
