using Game.Entities.ArmedEntities;
using UnityEngine;

namespace Game.Entities
{
    public class Enemy : ArmedEntity
    {
        // AI
        protected override bool CanJump => false;
        
        protected override void Die()
        {
            Debug.Log("Enemy Died");
        }
    }
}