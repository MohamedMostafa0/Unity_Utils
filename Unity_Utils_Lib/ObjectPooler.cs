using UnityEngine;
using System.Collections.Generic;
using System;

namespace Unity_Utils_Lib
{
    [Serializable]
    public class ObjectPoolCollection
    {
        public string tag;
        public ObjectPoolItem item;
    }
    [Serializable]
    public class ObjectPoolItem
    {
        public string objectToPoolPath;
        public int amountToPool;
        public bool shouldExpand;
    }

    public class ObjectPooler : BaseSingleton<ObjectPooler>
    {
        public List<ObjectPoolCollection> collection;

        private Dictionary<string, List<GameObject>> pooledObjects;

        private void Start()
        {
            pooledObjects = new Dictionary<string, List<GameObject>>();

            foreach (ObjectPoolCollection item in collection)
            {
                ObjectPoolItem collectionItem = item.item;
                List<GameObject> objs = new List<GameObject>();
                for (int i = 0; i < collectionItem.amountToPool; i++)
                {
                    GameObject obj = Instantiate(Resources.Load<GameObject>(collectionItem.objectToPoolPath));
                    obj.SetActive(false);
                    objs.Add(obj);
                }
                pooledObjects.Add(item.tag, objs);
            }
        }
        public GameObject GetPooledObject(string tag)
        {
            GameObject obj = null;
            if (pooledObjects.TryGetValue(tag, out List<GameObject> objs))
            {
                obj = objs.Find(a => !a.activeInHierarchy);
                if(obj == null)
                {
                    ObjectPoolCollection pool = collection.Find(a => a.tag == tag);
                    if (pool.item.shouldExpand)
                    {
                        obj = Instantiate(Resources.Load<GameObject>(pool.item.objectToPoolPath));
                        objs.Add(obj);
                    }
                }
                else
                {
                    obj.SetActive(true);
                }
            }
            else
            {
                throw new Exception("No Pool With This Tag");
            }
            return obj;
        }
    }
}
