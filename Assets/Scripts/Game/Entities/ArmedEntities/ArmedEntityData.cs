using Game.Weapons;
using UnityEngine;

namespace Game.Entities.ArmedEntities
{
    [CreateAssetMenu(menuName = "EntityData/ArmedEntityData")]
    public abstract class ArmedEntityData : EntityData
    {
        public WeaponData WeaponData => _weaponData;
        public abstract override Entity Prefab { get; }

        [Header("References")]
        [SerializeField] private WeaponData _weaponData;
    }
}