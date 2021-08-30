using UnityEngine;

namespace Game.Weapons.Bullets
{
    [CreateAssetMenu(menuName = "Game/Weapons/BulletData")]
    class BulletData : ScriptableObject
    {
        public float Damage => _damage;

        [Header("References")]
        [SerializeField] private Bullet _prefab;
        [Header("Parameters")]
        [SerializeField] private float _damage;

        public Bullet Spawn(Vector2 position, Quaternion rotation)
        {
            var bullet = Instantiate(_prefab, position, rotation);
            bullet.Initialize(this);

            return bullet;
        }
    }
}