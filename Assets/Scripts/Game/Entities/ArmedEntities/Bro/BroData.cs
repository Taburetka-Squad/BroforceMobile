using Game.Abilities;
using Game.Entities.ArmedEntities;
using Game.Entities.ArmedEntities.Bro;
using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData/BroData", order = 0)]
    public class BroData : ArmedEntityData
    {
        public ScriptableAbility Ability => _ability;
        public float SlideSpeed => _slideSpeed;
        public BroType BroType => _broBroType;
        public MeleeScriptableAttack Attack => _scriptableMeleeAttack;

        [SerializeField] private Bro _broPrefab;
        [SerializeField] private ScriptableAbility _ability;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private BroType _broBroType;
        [SerializeField] private MeleeScriptableAttack _scriptableMeleeAttack;

        public Bro CreateInstance()
        {
            var instance = Instantiate(_broPrefab);
            instance.Initialize(this);
            return instance;
        }
    }
}