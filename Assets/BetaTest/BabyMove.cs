using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMove : Movement
{
    public bool active = false;
    public bool grabbed = false;
    public bool bath = false;

    public Vector3 grabbedOffset;

    protected override void MovementInput()
    {
        if (active && !grabbed && !bath)
        {
            Move(InputHandle.GetBabyMovement());
        }

        if (grabbed)
        {
            Wiggle(InputHandle.GetBabyMovement());
            transform.position = transform.parent.position + grabbedOffset;
        }
    }

    void Wiggle(Vector2 dir)
    {
        switch (dir.x)
        {
            case 1:
                break;
            case -1:
                break;
            default:
                break;
        }

        switch (dir.y)
        {
            case 1:
                break;
            case -1:
                break;
            default:
                break;
        }
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
