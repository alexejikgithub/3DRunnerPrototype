using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Pool
{
    public class ObjectPoolController<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private List<T> _poolObjects;
        [SerializeField] private T prefabToPool;


        private T _currentElement;

        public T PrefabToPool => prefabToPool;

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