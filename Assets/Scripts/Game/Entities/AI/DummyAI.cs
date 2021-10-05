using UnityEngine;

namespace Game.Entities
{
    public class DummyAI : BaseAI
    {
        protected override bool CanJump => false;

        private void Update()
        {
            React();
        }

        public override void TakeDamage(int damage) { }
        protected override void OnDied() { }
    }
}
