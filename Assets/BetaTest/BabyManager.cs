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
            babies[currentBaby].SetActive();
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
        }
    }

    public void Switch()
    {
        babies[currentBaby].SetInactive();
        currentBaby++;

        if (currentBaby == babies.Length)
        {
            currentBaby = 0;
        }

        babies[currentBaby].SetActive();

        /*bool tripped = false;
        Debug.Log("Switching...");

        for (int i = 0; !tripped && i < babies.Length; i++)
        {
            if (babies[i].active)
            {
                babies[i].active = false;
                tripped = true;

                if (i == babies.Length - 1)
                {
                    babies[0].active = true;
                }
                else
                {
                    babies[i + 1].active = true;
                }
            }
        }

        if (!tripped)
        {
            babies[0].active = true;
        }*/
    }
}
