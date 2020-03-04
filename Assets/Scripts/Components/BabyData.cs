using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyData : MonoBehaviour
{
    public float speed = 6;
    public float wreckAmount = 0.2f;
    public float dirtPerInteract = 0.2f;
    public bool active = false;
    public bool grabbed = false;
    public bool bath = false;
    public bool messing = false;

    public float wreckSpeed = 1f;

    public Vector3 offset = Vector2.one * 0.1f;

    Rigidbody2D rb;

    private void Update()
    {
        if (grabbed)
        {
            transform.position = transform.parent.position + offset;
        }
    }

    public void Mess(RaycastHit2D item)
    {
        if (!messing)
        {
            rb = GetComponent<Rigidbody2D>();
            GetComponentInChildren<Meter>().Add(dirtPerInteract);
            wreckSpeed = item.transform.gameObject.GetComponent<Interactable>().cooldown;
            item.transform.gameObject.GetComponentInChildren<Meter>().Sub(wreckAmount);
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
        else
        {
            messing = false;
        }

        if (item.transform.gameObject.GetComponentInChildren<Meter>().percent != 0 && hit)
        {
            StartCoroutine(Messing(item));
            messing = false;
        }
    }
}
