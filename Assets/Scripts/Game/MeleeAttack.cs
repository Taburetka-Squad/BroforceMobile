using Game.Healths;
using UnityEngine;

namespace Game
{
    public class MeleeAttack : IAttack
    {
        private float _hitDelay;
        private Transform _transform;
        private int _damage;

        private float _lastHitTime;

        private const float MeleeAttackDistance = 0.52f;

        public MeleeAttack(float hitDelay, Transform transform, int damage)
        {
            _hitDelay = hitDelay;
            _transform = transform;
            _damage = damage;
        }
        
        public void Attack()
        {
            var elapsedTime = Time.time - _lastHitTime;
            var canHit = elapsedTime > _hitDelay;

            if (canHit == false) return;
            _lastHitTime = Time.time;

            var hit = Physics2D.Raycast(_transform.position, _transform.right, MeleeAttackDistance);


            if (hit.collider == null)
                return;
            if (hit.collider.TryGetComponent(out Health damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }
    }
}