using Game.Abilities;
using Game.Entities.ArmedEntities;
using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData/BroData", order = 0)]
    public class BroData : ArmedEntityData
    {
        public ScriptableAbility Ability => _ability;
        public int MeleeAttackDamage => _meleeAttackDamage;
        public float SlideSpeed => _slideSpeed;
        
        [SerializeField] private Bro _broPrefab;
        [SerializeField] private ScriptableAbility _ability;
        [SerializeField] private int _meleeAttackDamage;
        [SerializeField] private float _slideSpeed;

        public Bro CreateInstance()
        {
            var instance = Instantiate(_broPrefab);
            instance.Initialize(this);
            return instance;
        }
    }
}