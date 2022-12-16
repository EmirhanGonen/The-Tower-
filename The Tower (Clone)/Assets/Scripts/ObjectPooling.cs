using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }
    [System.Serializable]
    public struct Pool<T> where T : MonoBehaviour, new()
    {
        public List<T> poolObjects;
        public int poolAmount;
        public T objectPrefab;
    }
    public List<Pool<MonoBehaviour>> pools;
    private void Awake()
    {
        Instance = this;
        FillPool();
    }

    private void FillPool()
    {
        for (int i = 0; i < pools.Count; i++)
        {
            for (int k = 0; k < pools[i].poolAmount; k++)
            {
                var obj = Instantiate(pools[i].objectPrefab);
                obj.gameObject.SetActive(false);
                pools[i].poolObjects.Add(obj);
            }
        }
    }
    public T GetPooledObject<T>() where T : MonoBehaviour, new()
    {
        for (var i = 0; i < pools.Count; i++)
        {
            var objectList = pools[i].poolObjects;
            var objectType = pools[i].objectPrefab.GetType();

            if (objectType != typeof(T)) continue;

            for (var j = 0; j < objectList.Count; j++)
            {
                var obj = objectList[j];
                if (obj.gameObject.activeInHierarchy) continue;
                return obj as T;
            }
        }
        return null;
    }
}