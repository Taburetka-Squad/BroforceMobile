using UnityEngine;

namespace Game.Entities
{
    class Enemy : Entity
    {
        // AI
        public override void TakeDamage(int damage)
        {
            
        }

        protected override void OnDied()
        {
            Debug.Log("Enemy Died");
        }
    }
}