using System;

using UnityEngine;

using Game.Damage;
using Game.Healths;

namespace Game.Map.Blocks
{
    public class Dirt : Block, IDie
    {
        [Header("References")] 
        [SerializeField]
        private HealthData _healthData;
        
        public event Action Died;
        protected Health Health;
        
        //public override void OnMapInitialized()
        //{
        //    Health = _healthData.GetInstance();
        //    Health.Died += OnDied;
        //}

        private void OnDied()
        {
            Died?.Invoke();
            Health.Died -= OnDied;
            Died = null;
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            Health.TakeDamage(damage);
        }
    }
}