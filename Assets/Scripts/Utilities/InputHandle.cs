using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandle
{
    public static bool GetBabyInteractKey()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public static bool GetSitterInteractKey()
    {
        return Input.GetKeyDown(KeyCode.LeftControl);
    }

    public static bool GetSwitchKey()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public static Vector2 GetSitterMovement()
    {
        Vector2 temp = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            temp = new Vector2(temp.x, 1f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            temp = new Vector2(temp.x, -1f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            temp = new Vector2(-1f, temp.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            temp = new Vector2(1f, temp.y);
        }

        return temp;

        //return new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public static Vector2 GetBabyMovement()
    {
        Vector2 temp = Vector2.zero;

        if (Input.GetKey(KeyCode.R))
        {
            temp = new Vector2(temp.x, 1f);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            temp = new Vector2(temp.x, -1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            temp = new Vector2(-1f, temp.y);
        }
        else if (Input.GetKey(KeyCode.G))
        {
            temp = new Vector2(1f, temp.y);
        }

        return temp;
    }
}
