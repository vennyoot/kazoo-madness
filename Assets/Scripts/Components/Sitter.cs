using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitter : PlayerController
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void InputStuff()
    {
        if (InputHandle.GetSitterInteractKey())
        {
            Interact();
        }

        Move(InputHandle.GetSitterMovement());

        //sitter pickup key
    }
}
