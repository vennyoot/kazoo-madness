﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public bool test = false;
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            obj.GetComponent<Meter>().Add(0.2f);
            test = false;
        }
    }
}
