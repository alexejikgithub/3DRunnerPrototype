using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Pool
{
    public class ObjectPoolController<T> : MonoBehaviour where T : MonoBehaviour
    {
       
        [SerializeField] private T _prefabToPool;

        [SerializeField] private List<T> _poolObjects;

        private T _currentElement;

        public T PrefabToPool => _prefabToPool;


        private void Awake()
        {
            _poolObjects=GetComponentsInChildren<T>(true).ToList();
        }

        public T GetPooledGameObject()
        {
            if (_poolObjects.Count > 0)
            {
                _currentElement = _poolObjects[0];
                _currentElement.gameObject.SetActive(true);
                _poolObjects.RemoveAt(0);
                return _currentElement;
            }
            else
            {
                _currentElement = Instantiate(PrefabToPool, transform);
                return _currentElement;
            }
        }

        public void ReturnPooledGameObject(T item)
        {
            item.gameObject.SetActive(false);
            _poolObjects.Add(item);
        }
    }
}