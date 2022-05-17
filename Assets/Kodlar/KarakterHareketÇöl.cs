using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KarakterHareketÇöl : MonoBehaviour
{
    public GameObject oyun_bitti_pnl;
    public Animator animasyon;
    public Camera anakamera;

    public Rigidbody rigi;
    bool carptı = true, sag = true;
    public TextMeshProUGUI puanText;
    int puans = 0;
    [SerializeField]
    private float speed = 6f;

    float hiz = 5;
    bool isdead = false;
    public AudioSource kosma_ses_dosyasi, olum_ses;
    void Start()
    {
        isdead = false;
        PlayerPrefs.DeleteKey("puan1");//verileri siliyoruz.
        animasyon.GetComponent<Animator>();
        kosma_ses_dosyasi = GetComponent<AudioSource>();
        kosma_ses_dosyasi.Play();
        olum_ses.Stop();
    }

    void LateUpdate()
    {
        hareket();
    }
    private void hareket()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 0.5)
        {
            rigi.velocity = Vector3.zero; //eski güçleri siliyoruz.
            animasyon.SetBool("jump", true);
            rigi.velocity = Vector3.up * speed;
            Invoke("ziplama_iptal", 0.2f);
            kosma_ses_dosyasi.Stop();
            Invoke("sesbasla", 1.1f);
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
        if (carptı == true)
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
        if (carptı == false)
        {
            transform.Translate(0, 0, 0 * Time.deltaTime);
            enabled = false;
        }
        yield return new WaitForSeconds(7f);
        transform.Translate(0, 0, (hiz+0.2f) * Time.deltaTime);
        kosma_ses_dosyasi.pitch = 0.80f; //pitch ses hızı 
    }
    void ziplama_iptal()
    {
        animasyon.SetBool("jump", false);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "engel" &&!isdead)
        {
            animasyon.SetTrigger("dead");
            carptı = false;
            kosma_ses_dosyasi.Stop();
            olum_ses.Play();
            Invoke("sure", 3f);
            hiz = 0;
            isdead = true;
            //anakamera.transform.position = transform.position + new Vector3(0f, 3.4f, -4.0f);
        }
        if (collision.gameObject.name == "elmas")
        {
            Destroy(collision.gameObject);
            puans++;
            puanText.text = "" + puans;
        }
        PlayerPrefs.SetInt("puan1", puans);
    }
    void sure()
    {
        Time.timeScale = 0f;
        oyun_bitti_pnl.SetActive(true);
        kosma_ses_dosyasi.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bitis")
        {
            Invoke("sure", 0.3f);
            SceneManager.LoadScene(3);
        }
    }
}
