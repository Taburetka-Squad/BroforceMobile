using System;
using UnityEngine;

namespace Game.Healths
{
    public class Health : MonoBehaviour
    {
        public event Action Died;

        [SerializeField] private int _hitPoints;
        
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