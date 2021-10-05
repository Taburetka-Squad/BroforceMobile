using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    public class WanderAI : BaseAI
    {
        protected override bool CanJump => false;
        protected override void Die()
        {
            throw new System.NotImplementedException();
        }

        private void Update()
        {
            React();
        }

        protected override void React()
        {
            
        }


    }
}
