using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MM_CamController CamRef;
    AudioSource MM_Music;

    void Start()
    {
        MM_Music = GetComponent<AudioSource>();
        MM_Music.Play();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Settings()
    {
        CamRef.Settings = true;
    }

    public void TitleScreen()
    {
        Debug.Log("Clicked");
        CamRef.Settings = false;
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
