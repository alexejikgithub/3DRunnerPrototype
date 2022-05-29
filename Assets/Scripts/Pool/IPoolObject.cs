using UnityEngine;

namespace Scripts.Pool
{
    public interface IPoolObject<TPool, TComponent> where TPool : ObjectPoolController<TComponent> where TComponent : MonoBehaviour
    {
        public void SetPool(TPool pool);
        public void RemoveObject();
    }
}