using UnityEngine;

using Game.Damage;
using Game.Health;

namespace Game.Map.Blocks
{
    public class DestructibleBlock : Block, IDamageable
    {
        [Header("References")]
        [SerializeField] private HealthData _healthData;

        private Health.Health _health;

        private void Start()
        {
            _health = _healthData.GetInstance();
            _health.Died += OnDied;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnDied()
        {
            Destroy(gameObject);
        }
    }
}