using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitterMove : Movement
{
    protected override void MovementInput()
    {
        Move(InputHandle.GetSitterMovement());
    }
}
