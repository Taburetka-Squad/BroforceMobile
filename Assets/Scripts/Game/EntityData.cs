using Game;
using Game.Weapons;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "EntityData", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float Speed => _speed;
        [SerializeField] private float _speed;
        
        public float JumpForce => _jumpForce;
        [SerializeField] private float _jumpForce;
        
        public WeaponData WeaponData => _weaponData;
        [SerializeField] private WeaponData _weaponData;
        
        [SerializeField] private Entity _prefab;

        public Entity GetEntityInstance()
        {
            var entity = Instantiate(_prefab);
            entity.Initialize(this);
            return entity;
        }
    }
}