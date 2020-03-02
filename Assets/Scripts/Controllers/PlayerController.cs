using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerType { Sitter, B1, B2 }

    public PlayerType playerType;

    void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveByPlayerType();
    }

    void MoveByPlayerType()
    {
        switch (playerType)
        {
            case PlayerType.B1:

                InputHandle.GetBabyInteractKey();
                InputHandle.GetSwitchKey();
                break;

            case PlayerType.B2:

                InputHandle.GetBabyInteractKey();
                InputHandle.GetSwitchKey();
                break;

            case PlayerType.Sitter:

                InputHandle.GetSitterInteractKey();
                break;

            default:
                break;
        }
    }
}
