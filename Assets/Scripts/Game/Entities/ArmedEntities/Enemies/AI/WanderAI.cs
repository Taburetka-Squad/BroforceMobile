using System.Collections;
using UnityEngine;

namespace Game.Entities
{
    public class WanderAI : DummyAI
    {
        [SerializeField] private float _movementRange;
        [SerializeField] private float _movementDelay;
        protected override bool CanJump => false;

        private void FixedUpdate()
        {
            if (CanFire())
                Fire();


        }
        protected IEnumerator CanMove()
        {
            yield return new WaitForSeconds(1);
        }
        protected override void Die() { }
    }
}
