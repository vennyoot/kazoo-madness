using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float speed = 0;
    public Vector3 prevDir = Vector2.zero;

    protected Rigidbody2D rb;

    protected abstract void MovementInput();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementInput();
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
