using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip2 : MonoBehaviour
{
    public Transform karakter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = karakter.transform.position + new Vector3(0f, 2.7f, -4.5f);
    }
}
