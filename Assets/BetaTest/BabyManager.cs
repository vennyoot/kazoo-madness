using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyManager : MonoBehaviour
{
    public static BabyManager instance;
    public BabyMove[] babies;
    public int currentBaby;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        babies = FindObjectsOfType<BabyMove>();

        if (babies.Length > 0)
        {
            currentBaby = 0;
            SetBabyActive(true);
        }
        else
        {
            Debug.LogWarning("There are no babies...");
        }
    }

    private void Update()
    {
        if (InputHandle.GetSwitchKey())
        {
            Switch();
            GetComponent<AudioSwitch>().OnSwitch();
        }
    }

    public void Switch()
    {
        SetBabyActive(false);
        currentBaby++;

        if (currentBaby == babies.Length)
        {
            currentBaby = 0;
        }

        SetBabyActive(true);
    }

    public void SetBabyActive(bool b)
    {
        babies[currentBaby].SetActive(b);
        babies[currentBaby].GetComponent<BabyInteract>().SetActive(b);
    }
}