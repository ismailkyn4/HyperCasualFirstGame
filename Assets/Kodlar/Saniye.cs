using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saniye : MonoBehaviour
{
    int sure = 30;
    public TextMeshProUGUI sureText;
    public GameObject oyun_bitti_panel;
    void Start()
    {
        sureText.text =""+ sure;
        InvokeRepeating("zamanAzalt", 1, 1);
    }
    public void zamanAzalt()
    {
        sure--;
        sureText.text = "" + sure;
        if (sure==0)
        {
            CancelInvoke();
            Time.timeScale = 0f;
            oyun_bitti_panel.SetActive(true);
        }
    }
}
