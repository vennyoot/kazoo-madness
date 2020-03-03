using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed;

    private void Update()
    {
        InputStuff();
    }

    protected abstract void InputStuff();

    public void Interact()
    {

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
    }
}
