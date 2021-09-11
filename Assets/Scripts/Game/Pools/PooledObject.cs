using System;
using UnityEngine;

namespace Game.Pools
{
    public abstract class PooledObject : MonoBehaviour
    {
        public abstract event Action<PooledObject> Disabled;
    }
}