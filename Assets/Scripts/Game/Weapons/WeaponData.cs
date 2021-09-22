using UnityEngine;

using Game.Weapons.Bullets;

namespace Game.Weapons
{
    [CreateAssetMenu(menuName = "Game/Weapons/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public BulletData BulletData => _bulletData;
        public float FireRate => _fireRate;

        [Header("References")]
        [SerializeField] private Weapon _prefab;
        [SerializeField] private BulletData _bulletData;
        [Header("Parameters")]
        [SerializeField] private float _fireRate;

        public Weapon CreateInstance(Transform parent)
        {
            var weapon = Instantiate(_prefab, parent);
            weapon.Initialize(this);

            return weapon;
        }
    }
}