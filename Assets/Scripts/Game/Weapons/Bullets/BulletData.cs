using UnityEngine;

namespace Game.Weapons.Bullets
{
    [CreateAssetMenu(menuName = "Game/Weapons/BulletData")]
    public class BulletData : ScriptableObject
    {
        public float Damage => _damage;
        public float Speed => _speed;
        public float MaxDistance => _maxDistance;
        
        [Header("References")]
        [SerializeField] private Bullet _prefab;
        
        [Header("Parameters")]
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private int _maxDistance;
        
        public Bullet CreateInstance()
        {
            var bullet = Instantiate(_prefab);
            bullet.Initialize(this);

            return bullet;
        }
    }
}