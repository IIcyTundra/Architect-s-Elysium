using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MM_CamController CamRef;

    public GameObject[] ScreenChange;
    public AudioClip[] BttnSound;
    public AudioSource AP, ST;
    public AudioClip[] VoiceLines;
    void Start()
    {
        AP = GetComponent<AudioSource>();
        ST = GameObject.Find("SoundTest").GetComponentInChildren<AudioSource>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        ScreenChange[0].SetActive(true);
        ScreenChange[1].SetActive(false);
        ScreenChange[2].SetActive(false);
    }
    public void PlayGame()
    {
        AP.clip = BttnSound[0];
        AP.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        
    }

    public void SoundTest()
    {
        AP.clip = BttnSound[0];
        AP.Play();
        ScreenChange[0].SetActive(false);
        ScreenChange[1].SetActive(false);
        ScreenChange[2].SetActive(true);
    }

    public void Settings()
    {
        // CamRef.Settings = true;
        AP.clip = BttnSound[0];
        AP.Play();
        ScreenChange[0].SetActive(false);
        ScreenChange[1].SetActive(true);
        ScreenChange[2].SetActive(false);
    }

    public void TitleScreen()
    {
        Debug.Log("Clicked");
        // CamRef.Settings = false;
        AP.clip = BttnSound[1];
        AP.Play();
        ScreenChange[0].SetActive(true);
        ScreenChange[1].SetActive(false);
        ScreenChange[2].SetActive(false);
    }

    public void Etymology()
    {
        if(ST.isPlaying)
            ST.Stop();

        ST.clip = VoiceLines[0];
        ST.Play();
        
    }

    public void Rampancy()
    {
        if(ST.isPlaying)
            ST.Stop();

        ST.clip = VoiceLines[1];
        ST.Play();

    }
    public void LiminalV()
    {
        if(ST.isPlaying)
            ST.Stop();

        ST.clip = VoiceLines[2];
        ST.Play();
    }
    public void Shira()
    {
        if(ST.isPlaying)
            ST.Stop();

        ST.clip = VoiceLines[3];
        ST.Play();
    }
    public void Elysium()
    {
        if(ST.isPlaying)
            ST.Stop();

        ST.clip = VoiceLines[4];
        ST.Play();
    }



    public void Quit()
    {
        AP.clip = BttnSound[0];
        AP.Play();
        Debug.Log("QUIT");
        Application.Quit();
    }
}
