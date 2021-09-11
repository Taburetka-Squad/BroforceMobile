using UnityEngine;

namespace Game.Pools
{
    abstract class PooledObject : MonoBehaviour
    {
        private IPoolReturn _pool;

        public void AssignPool(IPoolReturn pool)
        {
            _pool = pool;
        }
        public void Enable()
        {
            gameObject.SetActive(true);
        }
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        protected void ReturnToPool()
        {
            _pool.ReturnToPool(this);
        }
    }
}