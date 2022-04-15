using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBall : MonoBehaviour
{
    private Queue<GameObject> pooledObjects; //s�ra olu�tur.
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();

        for(int i=0; i<poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);

            pooledObjects.Enqueue(obj); //enqueue s�raya sokar.

        }
    }
    public GameObject GetPooledObject()   
    {
        GameObject obj = pooledObjects.Dequeue();

        obj.SetActive(true);

        pooledObjects.Enqueue(obj);

        return obj;
    }
}
