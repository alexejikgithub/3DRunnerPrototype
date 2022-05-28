
using UnityEngine;


public enum RoadBlockType
{
    Finish,
    Empty,
    WithCoins1,
    WithCoins2
}
public class RoadBlockComponent : MonoBehaviour, IPoolObject
{
    [SerializeField] private float _length;
    [SerializeField] private RoadBlockType _type;
    public float Length => _length;
    public RoadBlockType Type => _type;


    private ObjectPoolController _pool;

    public void SetPool(ObjectPoolController pool)
    {
        _pool = pool;
    }

    public void RemoveObject()
    {
        StopAllCoroutines();
        if (_pool != null)
            _pool.ReturnPooledGameObject(gameObject);
        else
            Destroy(gameObject);
    }
}
