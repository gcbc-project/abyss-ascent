using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; set; }
    
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefap;
        public int Size;
        public Transform Parent;
    }
    [SerializeField] List<Pool> _pools;
    private Dictionary<string, Queue<GameObject>> _poolDict;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _poolDict = new Dictionary<string, Queue<GameObject>>();

        InitializePools();
    }

    private void InitializePools()
    {
        foreach (var pool in _pools)
        {
            AddPool(pool.Tag, pool.Size, pool.Prefap, pool.Parent);
        }
    }

    public GameObject SpawnPool(string tag,Vector3 spawnPoint)
    {
        if (!_poolDict.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = _poolDict[tag].Dequeue();
        obj.transform.position = spawnPoint;
        _poolDict[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }

    public void ReturnPool(string tag,GameObject obj)
    {
        if (!_poolDict.ContainsKey(tag))
        {
            return;
        }
        obj.SetActive(false);
        _poolDict[tag].Enqueue(obj);
    }

    private void AddPool(string tag, int size,GameObject prefap, Transform parent)
    {
        if (_poolDict.ContainsKey(tag))
        {
            return;
        }

        Queue<GameObject> objPool = new Queue<GameObject>();

        for(int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefap);
            obj.transform.SetParent(parent);
            obj.SetActive(false);
            objPool.Enqueue(obj);
        }
        _poolDict.Add(tag, objPool);
    }
}
