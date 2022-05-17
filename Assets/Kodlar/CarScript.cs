using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float carSpeed = 5f;
    bool carpma = true;
    public GameObject cocuk;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (carpma==true)
        {
            transform.Translate(0, 0, carSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, 0*Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name=="cocuk")
        {
            carpma = false;
        }
    }
}
