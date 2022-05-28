using System.Collections.Generic;
using UnityEngine;


public class ObjectPoolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _poolObjects;
    [SerializeField] private GameObject _objectToPool;


    private GameObject _currentElement;


    public GameObject GetPooledGameObject()
    {
        if (_poolObjects.Count > 0)
        {
            _currentElement = _poolObjects[0];
            _currentElement.SetActive(true);
            _poolObjects.RemoveAt(0);
            return _currentElement;
        }
        else
        {
            _currentElement = Instantiate(_objectToPool, transform);
            return _currentElement;
        }
    }

    public void ReturnPooledGameObject(GameObject item)
    {
        item.SetActive(false);
        _poolObjects.Add(item);
    }
}