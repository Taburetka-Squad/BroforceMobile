using Game.Health;
using Game.Weapons;

using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData", order = 0)]
    public class EntityData : ScriptableObject
    {
        public Entity Prefab => _prefab;
        public WeaponData WeaponData => _weaponData;
        public HealthData HealthData => _healthData;

        public float Speed => _speed;
        public float JumpForce => _jumpForce;

        [Header("References")]
        [SerializeField] private Entity _prefab;
        [SerializeField] private HealthData _healthData;
        [SerializeField] private WeaponData _weaponData;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        
        public Entity CreateInstance()
        {
            var entity = Instantiate(_prefab);
            entity.Initialize(this);

            return entity;
        }
    }
}