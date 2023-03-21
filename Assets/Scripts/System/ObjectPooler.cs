using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    private static ObjectPooler poolInstance;
    public static ObjectPooler instance
    {
        get
        {
            if (poolInstance == null) 
                poolInstance = FindObjectOfType<ObjectPooler>();
            return poolInstance;
        }
    }

    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    Dictionary<string, GameObject> pooledObjects;
    Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        pooledObjects = new Dictionary<string, GameObject>();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var item in pools)
        {
            RegisterObject(item);
        }
    }

    private void RegisterObject(Pool item)
    {
        if (pooledObjects.ContainsKey(item.prefab.tag)) return;

        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < item.size; i++)
        {
            GameObject newObj = Instantiate(item.prefab, transform);
            newObj.SetActive(false);
            objectPool.Enqueue(newObj);
        }
        pooledObjects.Add(item.prefab.tag, item.prefab);
        poolDictionary.Add(item.prefab.tag, objectPool);
    }

    public GameObject ActivateObject(string tag)
    {
        if (!pooledObjects.ContainsKey(tag)) throw new KeyNotFoundException();

        Queue<GameObject> objectPool = poolDictionary[tag];
        if (objectPool.Count == 0)
        {
            GameObject newObj = Instantiate(pooledObjects[tag], transform);
            return newObj;
        }

        GameObject obj = objectPool.Dequeue();
        return obj;
    }

    public void DeactivateObject(GameObject obj)
    {
        if (!pooledObjects.ContainsKey(obj.tag)) throw new KeyNotFoundException();

        Queue<GameObject> objectPool = poolDictionary[obj.tag];
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
