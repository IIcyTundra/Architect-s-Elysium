using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Teleporters;
 
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("AAAAAAA");
        StartCoroutine(ChillTfOut(1, collision.gameObject));
    }


    private IEnumerator ChillTfOut(float time, GameObject obj)
    {
        if (obj.gameObject.CompareTag("Teleporter"))
        {
            Player.transform.position = Teleporters[0].transform.position;
            Teleporters[0].SetActive(false);
        }
        if (obj.gameObject.CompareTag("SecondTeleporter"))
        {
            Player.transform.position = Teleporters[1].transform.position;
            Teleporters[1].SetActive(false);
        }
        if (obj.gameObject.CompareTag("ThirdTeleporter"))
        {
            Player.transform.position = Teleporters[2].transform.position;
            Teleporters[2].SetActive(false);

        }
        if (obj.gameObject.CompareTag("FourthTeleporter"))
        {
            Player.transform.position = Teleporters[3].transform.position;
            Teleporters[3].SetActive(false);
        }

        yield return new WaitForSeconds(time);
        Teleporters[1].SetActive(true);
        Teleporters[0].SetActive(true);
        Teleporters[2].SetActive(true);
        Teleporters[3].SetActive(true);

    }
}