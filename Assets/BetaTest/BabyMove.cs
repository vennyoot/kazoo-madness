using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMove : Movement
{
    public bool active = false;
    public bool grabbed = false;
    public bool bath = false;

    protected override void MovementInput()
    {
        if (active)
        {
            Move(InputHandle.GetBabyMovement());
        }
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
