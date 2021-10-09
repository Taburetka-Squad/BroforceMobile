using UnityEngine;

namespace Game
{
    public abstract class ScriptableAttack : ScriptableObject
    {
        public abstract IAttack GetInstance(Transform parent);
    }
}