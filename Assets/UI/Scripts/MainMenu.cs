using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MM_CamController CamRef;

    public GameObject[] ScreenChange;
    public AudioClip[] BttnSound;
    public AudioSource AP;

    void Start()
    {
        AP = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        ScreenChange[0].SetActive(true);
        ScreenChange[1].SetActive(false);
    }
    public void PlayGame()
    {
        AP.clip = BttnSound[0];
        AP.Play();
        SceneManager.LoadScene(1);
        
    }

    public void Settings()
    {
        // CamRef.Settings = true;
        AP.clip = BttnSound[0];
        AP.Play();
        ScreenChange[0].SetActive(false);
        ScreenChange[1].SetActive(true);
    }

    public void TitleScreen()
    {
        Debug.Log("Clicked");
        // CamRef.Settings = false;
        AP.clip = BttnSound[1];
        AP.Play();
        ScreenChange[0].SetActive(true);
        ScreenChange[1].SetActive(false);
    }

    public void Quit()
    {
        AP.clip = BttnSound[0];
        AP.Play();
        Debug.Log("QUIT");
        Application.Quit();
    }
}
