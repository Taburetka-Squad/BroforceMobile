using Game.Abilities;
using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "BroData", order = 0)]
    public class BroData : EntityData
    {
        public Bro BroPrefab => _broPrefab;
        public ScriptableAbility Ability => _ability;
        public int MeleeAttackDamage => _meleeAttackDamage;
        public float SlideSpeed => _slideSpeed;
        
        [SerializeField] private Bro _broPrefab;
        [SerializeField] private ScriptableAbility _ability;
        [SerializeField] private int _meleeAttackDamage;
        [SerializeField] private float _slideSpeed;

        public override Entity CreateInstance()
        {
            return Instantiate(BroPrefab);
        }
    }
}