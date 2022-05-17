using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puanCekme : MonoBehaviour
{
    public TextMeshProUGUI puan_text;
    void Start()
    {
        // PlayerPrefs.DeleteKey("puan1");
        puan_text.text = "" + PlayerPrefs.GetInt("puan1");
    }
}
