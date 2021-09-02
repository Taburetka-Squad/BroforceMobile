using UnityEngine;

namespace Game.Weapons.Bullets
{
    [CreateAssetMenu(menuName = "Game/Weapons/BulletData")]
    class BulletData : ScriptableObject
    {
        public float Damage => _damage;
        public float Speed => _speed;

        [Header("References")]
        [SerializeField] private Bullet _prefab;
        [Header("Parameters")]
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;

        public Bullet Spawn(Vector2 position, Quaternion rotation)
        {
            var bullet = Instantiate(_prefab, position, rotation);
            bullet.Initialize(this);

            return bullet;
        }
    }
}