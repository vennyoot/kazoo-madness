using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyManager : MonoBehaviour
{
    public static BabyManager instance;
    public BabyMove[] babies;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        babies = FindObjectsOfType<BabyMove>();
    }
}
