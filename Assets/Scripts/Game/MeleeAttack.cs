using UnityEngine;

using Game.Healths;

namespace Game
{
    public class MeleeAttack : IAttack
    {
        private const float MeleeAttackDistance = 0.52f;

        private readonly MeleeAttackData _data;
        private readonly Transform _transform;

        private float _lastHitTime;

        public MeleeAttack(MeleeAttackData data, Transform transform)
        {
            _data = data;
            _transform = transform;
        }

        private float HitDelay => 1f / _data.HitRate;
        
        public void Attack()
        {
            var elapsedTime = Time.time - _lastHitTime;
            var canHit = elapsedTime > HitDelay;

            if (canHit == false) return;
            _lastHitTime = Time.time;

            var hit = Physics2D.Raycast(_transform.position, _transform.right, MeleeAttackDistance);

            if (hit.collider == null)
                return;

            if (hit.collider.TryGetComponent(out Health damageable))
                damageable.TakeDamage(_data.Damage);
        }
    }
}