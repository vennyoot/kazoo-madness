using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public bool test1 = false;
    public bool test2 = false;
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        if (test2)
        {
            obj.GetComponent<ObjectDisplay>().TapToClean();
            test2 = false;
        }
    }
}
