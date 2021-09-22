using UnityEngine;

namespace Game.Abilities
{
    public interface IAbility
    {
        public void Use(Transform startTransform);
    }
}