using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMove : Movement
{
    private Animator _anim;
 
    public bool active = false;
    public bool grabbed = false;
    public bool bath = false;

    public Vector3 grabbedOffset;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    protected override void MovementInput()
    {
        if (active && !grabbed && !bath)
        {
            Move(InputHandle.GetBabyMovement());
            if (Input.GetKey(KeyCode.R))
            {
                _anim.SetBool("Back", true);
            }
            else if (Input.GetKey(KeyCode.F))
            {
                _anim.SetBool("Front", true);
            }
            else if (Input.GetKey(KeyCode.G))
            {
                _anim.SetBool("Side", true);
            }
            else if (Input.GetKey(KeyCode.D))
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
