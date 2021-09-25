using UnityEngine;

namespace Game.Abilities
{
    public abstract class ScriptableAbility : ScriptableObject, IAbility
    {
        public abstract void Use(Transform startTransform);
    }
}