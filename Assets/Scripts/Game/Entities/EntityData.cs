using Game.Healths;
using Game.Weapons;

using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData", order = 0)]
    public abstract class EntityData : ScriptableObject
    {
        public WeaponData WeaponData => _weaponData;

        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float JumpDelay => _jumpDelay;
        
        [Header("References")]
        [SerializeField] private WeaponData _weaponData;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpDelay;

        public abstract Entity CreateInstance();
    }
}