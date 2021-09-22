using UnityEngine;

namespace Game.Abilities
{
    [CreateAssetMenu(menuName = "Abilities/Grenades", order = 0)]
    public class GrenadeAbility : ScriptableObject, IAbility
    {
        [SerializeField] private Grenade _prefab;
        [SerializeField] private float _throwForce;

        public void Use(Transform startTransform)
        {
            var grenade = Instantiate(_prefab, startTransform.position, startTransform.rotation);
            grenade.GetComponent<Rigidbody2D>().AddForce(startTransform.right * _throwForce, ForceMode2D.Impulse);
        }
    }
}