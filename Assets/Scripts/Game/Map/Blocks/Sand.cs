using System;
using Game.Healths;
using UnityEngine;

namespace Game.Map.Blocks
{
    public class Sand : Block, IFall
    {
        public event Action Fell;
        
        public override void OnMapInitialized()
        {
            if (!TryGetBottomNeighbor(out var bottomNeighbor)) return;

            if (bottomNeighbor.TryGetComponent(out IDamageable die))
            {
                die.Health.Died += OnBottomNeighborDie;
            }

            if (bottomNeighbor.TryGetComponent(out IFall fall))
            {
                fall.Fell += OnFell;
            }
        }

        private void OnFell()
        {
            Fall();
        }

        protected override void Die()
        {
            Fell = null;
            Destroy(gameObject);
        }

        private bool TryGetBottomNeighbor(out Collider2D collider)
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, 1);
            collider = hit.collider;
            return hit.collider != null;
        }

        private void OnBottomNeighborDie()
        {
            Fall();
        }

        private void Fall()
        {
            if (Rigidbody2D != null)
            {
                Fell?.Invoke();
                Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                Rigidbody2D.gravityScale = 1;
            }
        }
    }
}