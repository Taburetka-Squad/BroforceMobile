using UnityEngine;

namespace Game.Abilities
{
    [CreateAssetMenu(menuName = "Abilities/Grenades", order = 0)]
    public class GrenadeAbility : ScriptableAbility
    {
        [SerializeField] private Grenade _prefab;
        [SerializeField] private float _throwForce;

        public override void Use(Transform startTransform)
        {
            var grenade = Instantiate(_prefab, startTransform.position, startTransform.rotation);
            grenade.Throw(startTransform.right, _throwForce);
        }
    }
}