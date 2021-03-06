﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath : MonoBehaviour
{
    public float cooldown = 5f;
    public GameObject child;


    public void BathTime(GameObject col)
    {
        child = col;
        child.transform.parent = transform;
        child.transform.position = transform.position;
        child.GetComponent<BabyMove>().bath = true;
        child.GetComponent<Animator>().SetBool("Bath", true);
        //start coroutine timer until baby regains movement
        StartCoroutine(EndBath());
        child.GetComponent<Animator>().SetBool("Clean", true);
    }

    IEnumerator EndBath()
    {
        child.GetComponent<Animator>().SetBool("Dirty", false);
        yield return new WaitForSeconds(cooldown);
        child.GetComponent<BabyInteract>().ResetMultiplier();
        child.transform.parent = null;
        child.GetComponent<Collider2D>().enabled = true;
        child.GetComponent<BabyMove>().bath = false;
        child.GetComponent<Animator>().SetBool("Bath", false);
        
        child = null;
        
    }
}
