using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    public class WanderAI : BaseAI
    {
        protected override bool CanJump => false;

        private void Update()
        {
            React();
        }

        protected override void React()
        {
            
        }

        public override void TakeDamage(int damage) { }
        protected override void OnDied() { }
    }
}
