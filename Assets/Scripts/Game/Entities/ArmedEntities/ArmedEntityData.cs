using UnityEngine;

namespace Game.Entities.ArmedEntities
{
    [CreateAssetMenu(menuName = "EntityData/ArmedEntityData")]
    public class ArmedEntityData : EntityData
    {
        public ScriptableAttack ScriptableAttack => _scriptableAttack;
        
        [Header("References")]
       
        [SerializeField] private ArmedEntity _armedEntityPrefab;
        [SerializeField] private ScriptableAttack _scriptableAttack;
        
    }
}