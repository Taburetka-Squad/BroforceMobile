using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Weapons/MeleeAttack")]
    public class MeleeScriptableAttack : ScriptableAttack
    {
        public int Damage => _damage;
        public float HitRate => _fireRate;

        [Header("Parameters")]
        [SerializeField] private int _damage;
        [SerializeField] private float _fireRate;
        
        public override IAttack GetInstance(Transform parent)
        {
            return new MeleeAttack(this, parent);
        }
    }
}