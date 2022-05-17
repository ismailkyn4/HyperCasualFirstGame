using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuphareket : MonoBehaviour
{
    int genislik = 2;
    float tekrarlamamiktari = 0.75f;

    void Start()
    {
        
    }
    void Update()
    {
        float x = Mathf.Cos(Time.time * tekrarlamamiktari) * genislik;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="cocuk")
        {
            tekrarlamamiktari = 0f;
        }
    }
}
