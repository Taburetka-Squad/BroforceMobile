using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Weapons/MeleeAttack")]
    public class MeleeAttackData : ScriptableObject
    {
        public int Damage => _damage;
        public float HitRate => _fireRate;

        [Header("Parameters")]
        [SerializeField] private int _damage;
        [SerializeField] private float _fireRate;

        public IAttack CreateInstance(Transform transform)
        {
            return new MeleeAttack(this, transform);
        }
    }
}