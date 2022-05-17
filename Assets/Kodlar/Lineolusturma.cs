using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineolusturma : MonoBehaviour
{
    LineRenderer cizgi;
    public Transform kup, kup1;
    void Start()
    {
        cizgi = GetComponent<LineRenderer>();
        cizgi.GetComponent<LineRenderer>().positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        cizgi.SetPosition(0, kup.position);
        cizgi.SetPosition(1, kup1.position);
    }
}
