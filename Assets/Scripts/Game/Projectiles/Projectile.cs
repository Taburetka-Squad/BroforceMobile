﻿using Game.Damage;
using Game.Pools;
using UnityEngine;

namespace Game.Projectiles
{
    public class Projectile : PooledObject
    {
        private int _damageAmount;

        public void Initialize(int damageAmount)
        {
            _damageAmount = damageAmount;
        }

        protected bool TryDamageObject(GameObject obj)
        {
            if (obj.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damageAmount);
                return true;
            }

            return false;
        }
    }
}