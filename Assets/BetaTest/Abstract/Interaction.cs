using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    Rigidbody2D rb;
    public float interactRange;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InteractInput();
    }

    public void CheckInteract()
    {
        Collider2D hit = Physics2D.OverlapBox(rb.position, rb.GetComponent<Collider2D>().bounds.size *1.1f, 0, LayerMask.GetMask("Interactable"));

        //RaycastHit2D hit = Physics2D.BoxCast(rb.position, rb.GetComponent<Collider2D>().bounds.size / 2, 0, GetComponent<Movement>().prevDir, interactRange, LayerMask.GetMask("Interactable"));

        if (hit)
        {
            Debug.Log("Found interaction");
            Interact(hit);
        }
    }

    protected abstract void InteractInput();
    protected abstract void Interact(Collider2D hit);

}
