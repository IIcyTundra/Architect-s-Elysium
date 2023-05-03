using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextScroller : MonoBehaviour
{
    public GameObject[] text;
    public AudioSource EtherealSpeak;
    public Animator transition;
    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        EtherealSpeak = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log(EtherealSpeak.time);
       if(EtherealSpeak.time >= 2.3f && EtherealSpeak.time < 7f)
       {
            text[0].SetActive(false);
            text[1].SetActive(true);
       }
       if(EtherealSpeak.time >= 7f && EtherealSpeak.time < 11f)
       {
            text[1].SetActive(false);
            text[2].SetActive(true);
       }
       if(EtherealSpeak.time >= 11f && EtherealSpeak.time < 14f)
       {
            text[2].SetActive(false);
            text[3].SetActive(true);
       }
       if(EtherealSpeak.time >= 14f && EtherealSpeak.time < 19f)
       {
            text[3].SetActive(false);
            text[4].SetActive(true);
       }
       if(EtherealSpeak.time >= 19f)
       {
            text[4].SetActive(false);
            text[5].SetActive(true);
       }
       if(!EtherealSpeak.isPlaying)
       {
            StartCoroutine(LoadMM());
       }
       

    }

    IEnumerator LoadMM()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }


    
}
