using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitterMove : Movement
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    protected override void MovementInput()
    {
        Move(InputHandle.GetSitterMovement());
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _anim.SetBool("Back", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _anim.SetBool("Front", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _anim.SetBool("Side", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _anim.SetBool("Left", true);
        }
        else
        {
            _anim.SetBool("Back", false);
            _anim.SetBool("Front", false);
            _anim.SetBool("Side", false);
            _anim.SetBool("Left", false);
        }
    }
}
