using UnityEngine;
using System.Collections.Generic;


public class BulletBehavior : MonoBehaviour
{

    public List<ObjectsPool> ObjectsList = new List<ObjectsPool>();

    static Transform thisTransform;
    static int[] numberObjects;
    static GameObject[][] stObjects;
    static public int numObjectsList;

    void Awake()
    {
        thisTransform = transform;
        numObjectsList = ObjectsList.Count;
        AddObjectsToPool();
    }

    void AddObjectsToPool()
    {

        numberObjects = new int[numObjectsList];
        stObjects = new GameObject[numObjectsList][];

        for (int num = 0; num < numObjectsList; num++)
        {
            numberObjects[num] = ObjectsList[num].numberObjects;
            stObjects[num] = new GameObject[numberObjects[num]];
            InstanInPool(ObjectsList[num].obj, stObjects[num]);
        }
 
    }

    static void InstanInPool(GameObject obj, GameObject[] objs)
    {

        for (int i = 0; i < objs.Length; i++)
        {
            objs[i] = Instantiate(obj);
            objs[i].SetActive(false);
            objs[i].transform.parent = thisTransform;
        }

  
    }


    static public GameObject GiveObj(int numElement)
    {
        //Debug.Log(numberObjects.Length);
        for (int i = 0; i < numberObjects[numElement]; i++) if (!stObjects[numElement][i].activeSelf) return stObjects[numElement][i];

        Debug.Log("Objects in the pool are over!");
        return null;
   
    }

    static public void Takeobj(GameObject obj)
    {

        if (obj.activeSelf) obj.SetActive(false);
        if (obj.transform.parent != thisTransform) obj.transform.parent = thisTransform;
 
    }

}

[System.Serializable]

public class ObjectsPool
{

    public GameObject obj;
    public int numberObjects = 100;

}