using System;
using UnityEngine;

namespace Game.Health
{
    public class Health
    {
        public event Action Died;

        private int _hitPoints;

        public Health(int hitPoints)
        {
            _hitPoints = hitPoints;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            _hitPoints = Mathf.Clamp(_hitPoints, 0, int.MaxValue);

            if (_hitPoints == 0)
            {
                Died?.Invoke();
            }
        }
    }
}