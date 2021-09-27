using System;
using UnityEngine;

using Game.Damage;
using Game.Healths;

namespace Game.Map.Blocks
{
    public class DestructibleBlock : Block, IDie
    {
        [Header("References")]
        [SerializeField] private HealthData _healthData;

        public event Action Died;
        private Health _health;

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