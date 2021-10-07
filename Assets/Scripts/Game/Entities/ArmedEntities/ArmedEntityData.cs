using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Entities.ArmedEntities
{
    [CreateAssetMenu(menuName = "EntityData/ArmedEntityData")]
    public class ArmedEntityData : EntityData
    {
        public IAttack Attack => _attack;
        
        [Header("References")]
       
        [SerializeField] private ArmedEntity _armedEntityPrefab;

        private IAttack _attack;

        private void OnValidate()
        {
            if (_attack != null)
            {
                
            }
        }
    }
}