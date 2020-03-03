using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyData : MonoBehaviour
{
    public float speed = 6;
    public bool active = false;
    public bool grabbed = false;
    public bool bath = false;
    public bool messing = false;

    public float cooldown = 1f;

    public Vector3 offset = Vector2.one * 0.1f;

    private void Update()
    {
        if (grabbed)
        {
            transform.position = transform.parent.position + offset;
        }
    }

    public void Mess(RaycastHit2D item)
    {
        cooldown = item.transform.gameObject.GetComponent<Interactable>().cooldown;
        StartCoroutine(Messing());
    }

    IEnumerator Messing()
    {
        yield return new WaitForSeconds(cooldown);
        //check if in range, stop coroutine if not
        Debug.Log("messing up this much: " + cooldown);
        StartCoroutine(Messing());
    }
}
