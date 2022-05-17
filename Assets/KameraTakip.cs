using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{

    Vector3 newTransform;
    public Transform karakter;
    bool isdead=false;
    private void Awake()
    {
        isdead = false;
    }
    void LateUpdate()
    {

            hareket();

    }
    public void hareket()
    {
        //transform.position = karakter.transform.position + new Vector3(0f, 2.7f, -4.5f);
        newTransform = karakter.transform.position + new Vector3(0f, 2.7f, -5.5f);
        transform.position = Vector3.Lerp(transform.position, newTransform, Time.deltaTime * 5.0f);
        //transform.position = Vector3.Lerp(transform.position, takip_edilen_kup.position, Time.deltaTime * 3.0f);

    }

}
