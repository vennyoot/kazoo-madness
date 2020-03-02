using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandle
{
    public static bool GetBabyInteractKey()
    {
        return Input.GetKey(KeyCode.A);
    }

    public static bool GetSitterInteractKey()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }

    public static bool GetSwitchKey()
    {
        return Input.GetKey(KeyCode.S);
    }
}
