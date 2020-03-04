using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitter : PlayerController
{
    public GameObject pickedup;
    public float cleanMultiplier = 1f;

    public float cleanSpeed = 1f;
    public bool cleaning;
    public float cleanAmount = 0.2f;

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
        if (hit.transform.gameObject.GetComponent<Interactable>().cleanliness != 1f)
        {
            cleanSpeed = hit.transform.gameObject.GetComponent<Interactable>().cooldown * cleanMultiplier;
            Clean(hit);
            //hit.transform.gameObject.GetComponent<Interactable>().Clean(hit);
        }

        if (hit.transform.gameObject.GetComponent<Bath>())
        {

        }
    }

    void Clean(RaycastHit2D item)
    {
        if (!cleaning)
        {
            item.transform.gameObject.GetComponentInChildren<Meter>().Add(cleanAmount);
            StartCoroutine(Cleaning(item));
            cleaning = true;
        }
    }

    IEnumerator Cleaning(RaycastHit2D item)
    {
        yield return new WaitForSeconds(cleanSpeed);
        //check if in range, quite coroutine if not
        //Collider2D hit = Physics2D.OverlapBox(rb.position, rb.GetComponent<Collider2D>().bounds.size + new Vector3(interactRange, interactRange), 0, LayerMask.GetMask("Interactable"));

        RaycastHit2D hit = Physics2D.BoxCast(rb.position, rb.GetComponent<Collider2D>().bounds.size / 2, 0, prevDir, interactRange, LayerMask.GetMask("Interactable"));

        Debug.Log("Cleaning...");

        if (hit == item)
        {
            Debug.Log("Clean: " + cleanSpeed);
            item.transform.gameObject.GetComponentInChildren<Meter>().Add(cleanAmount);
        }
        else
        {
            cleaning = false;
        }

        if (item.transform.gameObject.GetComponentInChildren<Meter>().percent != 1 && hit == item)
        {
            StartCoroutine(Cleaning(item));
            cleaning = false;
        }
    }

    /*public void Mess(RaycastHit2D item)
    {
        if (!messing)
        {
            rb = GetComponent<Rigidbody2D>();
            GetComponentInChildren<Meter>().Add(dirtPerInteract);
            wreckSpeed = item.transform.gameObject.GetComponent<Interactable>().cooldown;
            StartCoroutine(Messing(item));
            messing = true;
        }
    }
    
    IEnumerator Messing(RaycastHit2D item)
    {
        yield return new WaitForSeconds(wreckSpeed);
        //check if in range, stop coroutine if not
        Collider2D hit = Physics2D.OverlapBox(rb.position, rb.GetComponent<Collider2D>().bounds.size + new Vector3(0.5f, 0.5f), 0, LayerMask.GetMask("Interactable"));
        Debug.Log("Messing...");
        if (hit)
        {
            Debug.Log("Mess: " + wreckSpeed);
            item.transform.gameObject.GetComponentInChildren<Meter>().Sub(wreckAmount);
        }

        if (item.transform.gameObject.GetComponentInChildren<Meter>().percent != 0 && hit)
        {
            StartCoroutine(Messing(item));
            messing = false;
        }
    }*/
}
