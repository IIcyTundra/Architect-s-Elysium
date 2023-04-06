using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    AudioSource Level_Music;
    GameObject[] EnemiesInLevel;

    public Player3D_Controller pHealth;

    public TextMeshProUGUI EnemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        Level_Music = GetComponent<AudioSource>();
        Level_Music.Play();
        EnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(EnemiesInLevel.Length);
        EnemiesLeft.SetText("Enemies Left:" + EnemiesInLevel.Length);
        lvlSucess();
    }


    public void lvlSucess()
    {
        if(EnemiesInLevel.Length == 0)
        {
            SceneManager.LoadScene(0);
        }
        else if(pHealth.CurrHealth <=0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
