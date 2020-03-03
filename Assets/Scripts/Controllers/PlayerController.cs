using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public float interactRange = 0.5f;

    protected Rigidbody2D rb;
    public float speed;

    Collider2D result;

    public Vector3 prevDir = Vector2.zero;

    private void Update()
    {
        InputStuff();
    }

    protected abstract void InputStuff();
    protected abstract void Interact(RaycastHit2D hit);

    public void CheckInteract()
    {
        //Collider2D overlap = Physics2D.OverlapBox(rb.position, rb.GetComponent<Collider2D>().bounds.size, 0, LayerMask.GetMask("Interactable"));
        RaycastHit2D hit = Physics2D.BoxCast(rb.position, rb.GetComponent<Collider2D>().bounds.size/2, 0, prevDir, interactRange, LayerMask.GetMask("Interactable"));

        if (hit)
        {
            Interact(hit);
        }
    }
    
    public void Move(Vector2 dir)
    {
        if (dir.x != 0 && dir.y != 0)
        {
            rb.position += speed * Time.deltaTime * new Vector2(0.7071f * dir.x, 0.7071f * dir.y);
        }
        else
        {
            rb.position += speed * Time.deltaTime * dir;
        }

        if (dir.x != 0 || dir.y != 0)
        {
            prevDir = dir;
        }
    }
}
