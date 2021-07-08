using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool0Special : MonoBehaviour
{

    public ObjectPool0Special SharedInstance0;
    [SerializeField] List<GameObject> pooledObjects;
    [SerializeField] GameObject objectToPool0;
    //TODO maybe in Game MAngaer instead
    [SerializeField] int amountToPool;



    private void Awake()
    {
        SharedInstance0 = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
       GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool0);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject0()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
