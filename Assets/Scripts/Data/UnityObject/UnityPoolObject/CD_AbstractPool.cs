using System;
using UnityEngine;

namespace Data.UnityObject
{
    public abstract class CD_AbstractPool<T> : ScriptableObject where T : class
    {
        public GameObject Prefab;
        public T Key;
        public int InitialSize;
        public bool IsExtensible;

        public virtual void ActivatePrefab() => Prefab.SetActive(true);
        public virtual void DeactivatePrefab() => Prefab.SetActive(false);
        public virtual GameObject PrefabFactory() => GameObject.Instantiate(Prefab);
    }
}