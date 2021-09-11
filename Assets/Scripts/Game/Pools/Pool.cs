using System.Collections.Generic;

namespace Game.Pools
{
    public class Pool<T> where T : PooledObject
    {
        private readonly Queue<T> _inactiveObjects = new Queue<T>();

        public void AddObjectToPool(T obj)
        {
            obj.Disabled += OnDisabled;
        }

        private void OnDisabled(PooledObject obj)
        {
            obj.gameObject.SetActive(false);
            ReturnObjectToPool(obj);
        }

        private void ReturnObjectToPool(PooledObject obj)
        {
            _inactiveObjects.Enqueue((T) obj);
        }

        public bool TryGetInactiveObject(out T pooledObject)
        {
            pooledObject = null;
            var hasObject = _inactiveObjects.Count > 0;

            if (hasObject)
            {
                pooledObject = _inactiveObjects.Dequeue();
                pooledObject.gameObject.SetActive(true);
            }

            return hasObject;
        }
    }
}