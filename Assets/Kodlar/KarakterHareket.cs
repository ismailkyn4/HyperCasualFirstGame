using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KarakterHareket : MonoBehaviour
{
    public GameObject oyun_bitti_pnl;
    public Animator animasyon;

    public Transform yol1,yol2;
    float hiz = 7;
    public Rigidbody rigi;
    bool carptı,sag=true;
    public TextMeshProUGUI puanText, puan_text;
    int puans = 0;
    [SerializeField]
    private float speed = 7f;
    public AudioSource kosma_ses_dosyasi,olum_ses;
    bool isdead =false;

    //[SerializeField]
    //Camera mainCamera;
    Vector3 newTransform;
    void Start()
    {
        isdead = false;
        PlayerPrefs.DeleteKey("puan1");//verileri siliyoruz.
        carptı = true;
        animasyon.GetComponent<Animator>();
        kosma_ses_dosyasi = GetComponent<AudioSource>();
        kosma_ses_dosyasi.Play();
        olum_ses.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SON_1")
        {
            yol2.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z +180f );
        }
        if (other.gameObject.name == "SON_2")
        {
            yol1.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 180f);
        }
    }
    void LateUpdate()
    {        
        hareket();
        //if (!isdead)
        //{
        //    Kamerahareket();
        //}
        //else
        //{
        //    mainCamera.transform.position = transform.position + new Vector3(0f, 3.4f, -10.0f);
        //}
    }
    private void hareket()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y<0.5 )
        {
            rigi.velocity = Vector3.zero; //eski güçleri siliyoruz.
            animasyon.SetBool("jump", true);
            rigi.velocity = Vector3.up * speed; 
            Invoke("ziplama_iptal", 0.2f);
            kosma_ses_dosyasi.Stop();
            Invoke("sesbasla", 0.9f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && carptı == true)
        {
            sag = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && carptı == true)
        {
            sag = false;
        }
        if (sag)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.6f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
        }
        else
        { 
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.6f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
        }
        if (carptı==true)
        {
            transform.Translate(0, 0, hiz * Time.deltaTime);
            StartCoroutine(Sesvekarakterhizi());
        }
    }
    void sesbasla()
    {
        kosma_ses_dosyasi.Play();
    }
    public IEnumerator Sesvekarakterhizi()
    {
        yield return new WaitForSeconds(7f);
        hiz = 7.5f;
        transform.Translate(0, 0, hiz * Time.deltaTime);
        kosma_ses_dosyasi.pitch = 0.85f; //pitch ses hızı 
        yield return new WaitForSeconds(7f);
        transform.Translate(0,0, (hiz+1.0f) * Time.deltaTime);
        kosma_ses_dosyasi.pitch = 0.90f; //pitch ses hızı 
        yield return new WaitForSeconds(7f);
        transform.Translate(0, 0, (hiz+1.5f) * Time.deltaTime);
        kosma_ses_dosyasi.pitch = 1f; //pitch ses hızı 

    }
    void ziplama_iptal()
    {
        animasyon.SetBool("jump", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "engel" && !isdead)
        {
            animasyon.SetTrigger("dead");
            carptı = false;
            kosma_ses_dosyasi.Stop();
            Invoke("sure", 3f);
            olum_ses.Play();
            hiz = 0;
            isdead = true;

        }
        if (collision.gameObject.name == "elmas")
        {
            Destroy(collision.gameObject);
            puans++;
            
        }
        puanText.text = "" + puans;
        PlayerPrefs.SetInt("puan1", puans);
    }

    void sure()
    {        
        Time.timeScale = 0f;
        oyun_bitti_pnl.SetActive(true);
    }
}