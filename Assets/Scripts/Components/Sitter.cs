using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitter : PlayerController
{
    public GameObject pickedup;
    float cooldown = 1f;
    public float cleanMultiplier = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void InputStuff()
    {
        if (InputHandle.GetSitterInteractKey())
        {
            CheckInteract();
        }

        if (InputHandle.GetSitterPickUpKey())
        {
            PickUp();
        }

        Move(InputHandle.GetSitterMovement());
    }

    void PickUp()
    {
        if (pickedup == null)
        {
            Collider2D hit = Physics2D.OverlapBox(rb.position, rb.GetComponent<Collider2D>().bounds.size + new Vector3(interactRange, interactRange), 0, LayerMask.GetMask("Pickupable"));

            if (hit)
            {
                pickedup = hit.gameObject;
                pickedup.GetComponent<Collider2D>().enabled = false;
                pickedup.GetComponent<BabyData>().grabbed = true;

                pickedup.transform.parent = transform;
                //Debug.Log(pickedup.transform.parent.name);
            }
        }
        else
        {
            pickedup.transform.parent = FindObjectOfType<BabyManager>().transform;
            //Debug.Log(pickedup.transform.parent.name);

            pickedup.GetComponent<Collider2D>().enabled = true;
            pickedup.GetComponent<BabyData>().grabbed = false;
            pickedup = null;
        }
    }

    protected override void Interact(RaycastHit2D hit)
    {
        if (!hit.transform.gameObject.GetComponent<Interactable>().clean)
        {
            cooldown = hit.transform.gameObject.GetComponent<Interactable>().cooldown * cleanMultiplier;
            Clean();
            //hit.transform.gameObject.GetComponent<Interactable>().Clean(hit);
        }

        if (hit.transform.gameObject.GetComponent<Bath>())
        {

        }
    }

    void Clean()
    {
        StartCoroutine(Cleaning());
    }

    IEnumerator Cleaning()
    {
        yield return new WaitForSeconds(cooldown);
        //check if in range, quite coroutine if not
        Debug.Log("cleaning up this much: " + cooldown);
        StartCoroutine(Cleaning());
    }
}
