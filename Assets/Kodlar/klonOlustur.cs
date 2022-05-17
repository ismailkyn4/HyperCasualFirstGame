using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klonOlustur : MonoBehaviour
{
    public GameObject elmas,car,taxi,otobus,car_red;
    public Transform oyuncu;
    float silinme_zamani = 10.0f;

    float sag_X_koordinat = 1.46f;
    float sol_X_koordinat = -1.46f;
    void Start()
    {
        InvokeRepeating("nesne_klonla", 0, 0.5f);
    }
    void nesne_klonla()
    {
        int rastsayi = Random.Range(0, 100);
        if (rastsayi > 0 && rastsayi < 25)
        {
            klonla(elmas, 1.0f);
        }
        if (rastsayi >= 25 && rastsayi < 50)
        {
            klonla(elmas, 1f);
        }
        if (rastsayi >= 50 && rastsayi < 65)
        {
            klonla(car, 0f);
        }
        if (rastsayi >= 65 && rastsayi < 80)
        {
            klonla(car_red, 0f);
        }
        if (rastsayi >= 80 && rastsayi < 90)
        {
            klonla(taxi, 0f);
        }
        if (rastsayi >= 90 && rastsayi < 100)
        {
            klonla(otobus, 0f);
        }
    }
    void klonla(GameObject nesne,float Y_koordinat)
    {
        GameObject yeni_klon = Instantiate(nesne); //instantiate istenilen bi noktada istennilen bi nesneyi oluşturmaya yarar.
        int rastsayi = Random.Range(0, 100);
        if (rastsayi<50)
        {
            yeni_klon.transform.position = new Vector3(sag_X_koordinat, Y_koordinat, oyuncu.position.z + 20.0f);
        }
        if (rastsayi > 50)
        {
            yeni_klon.transform.position = new Vector3(sol_X_koordinat, Y_koordinat, oyuncu.position.z + 20.0f);
        }
        Destroy(yeni_klon, silinme_zamani);
    }
}
