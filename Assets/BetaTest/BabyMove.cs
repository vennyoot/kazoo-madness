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
        //might remove if tapping to escape
        if (!grabbed)
        {
            Move(InputHandle.GetBabyMovement());
        }

        if (InputHandle.GetSwitchKey())
        {
            //Switch();
        }
    }
}
