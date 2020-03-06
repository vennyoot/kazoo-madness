using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeBG : MonoBehaviour
{
    public RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        rect.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position);// + (Vector3.up * offset));
    }
}
