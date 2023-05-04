using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    AudioSource Level_Music;
    GameObject[] EnemiesInLevel;

    public Player_SO PS0_ref;

    public TextMeshProUGUI EnemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(EnemiesInLevel.Length);
        EnemiesLeft.SetText("Enemies Left: " + EnemiesInLevel.Length);
        lvlSucess();
    }


    public void lvlSucess()
    {
        if(EnemiesInLevel.Length == 0)
        {
            if(SceneManager.GetActiveScene().buildIndex != 4)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            else if(SceneManager.GetActiveScene().buildIndex == 4)
                SceneManager.LoadScene(0);
        }
        else if(PS0_ref.Health <=0)
        {
            
           StartCoroutine(BTM(1f));
        }
        
    }


    IEnumerator BTM (float timer)
    {
        //Destroy(GameObject.Find("Player"));
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(0);
    }
}
