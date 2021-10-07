using Game.Projectiles.Bullets;
using UnityEngine;

namespace Game.Weapons
{
    [CreateAssetMenu(menuName = "Game/Weapons/ShootWeaponData")]
    public class ShootWeaponData : ScriptableObject
    {
        public BulletData BulletData => _bulletData;
        public float FireRate => _fireRate;

        [Header("References")]
        [SerializeField] private WeaponPrefab _prefab;
        [SerializeField] private BulletData _bulletData;
        [Header("Parameters")]
        [SerializeField] private float _fireRate;

        public IAttack CreateInstance(Transform parent)
        {
            var weapon = Instantiate(_prefab);
            var shootWeapon = new ShootWeapon(this ,weapon.FirePoint);
            return shootWeapon;
        }
    }
}