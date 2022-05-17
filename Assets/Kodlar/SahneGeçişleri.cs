using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGeçişleri : MonoBehaviour
{
    public void oyna_btn()
    {
        SceneManager.LoadScene(1);
        Time.timeScale=1f;
    }
    public void oyun_sonu_btn()
    {
        Application.Quit();
    }
    public void sahne2_gec()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void yeniden_oyna1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void sahne_cıkıs()
    {
        SceneManager.LoadScene(0);
    }
    public void yenidenoyna2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void sahne3_gec()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    public void yeniden_oyna3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
}
