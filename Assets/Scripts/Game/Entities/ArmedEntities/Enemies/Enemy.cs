using UnityEngine;

namespace Game.Entities
{
    class Enemy : Entity
    {
        // AI
        protected override bool CanJump { get; }
        

        protected override void Die()
        {
            Debug.Log("Enemy Died");
        }
    }
}