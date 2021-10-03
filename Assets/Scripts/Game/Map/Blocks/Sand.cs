using Game.Healths;
using UnityEngine;

namespace Game.Map.Blocks
{
    public class Sand : Block
    {
        public override void OnMapInitialized()
        {
            if (!TryGetBottomNeighbor(out var bottomNeighbor)) return;

            if (bottomNeighbor.TryGetComponent(out Health die))
            {
                die.Died += OnBottomNeighborDie;
            }
        }
        
        protected override void Die()
        {
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
                Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                Rigidbody2D.gravityScale = 1;
            }
        }
    }
}