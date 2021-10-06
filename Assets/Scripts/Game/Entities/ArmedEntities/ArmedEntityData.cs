using Game.Weapons;
using UnityEngine;

namespace Game.Entities.ArmedEntities
{
    [CreateAssetMenu(menuName = "EntityData/ArmedEntityData")]
    public class ArmedEntityData : EntityData
    {
        public WeaponData WeaponData => _weaponData;

        [Header("References")]
        [SerializeField] private WeaponData _weaponData;
        [SerializeField] private ArmedEntity _armedEntityPrefab;
        
        public ArmedEntity CreateInstance()
        {
            var instance = Instantiate(_armedEntityPrefab);
            instance.Initialize(this);
            return instance;
        }
    }
}