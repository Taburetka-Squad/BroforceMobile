using System;

using UnityEngine;

using Game.Damage;
using Game.Healths;

namespace Game.Map.Blocks
{
    public class Sand : Block, IDie
    {
        [Header("References")] 
        [SerializeField]
        private HealthData _healthData;
        
        public event Action Died;
        protected Health Health;
        
        //public override void OnMapInitialized()
        //{
        //    Health = _healthData.GetInstance();
        //    Health.Died += OnDied;
            
        //    if (!TryGetBottomNeighbor(out var bottomNeighbor)) return;

        //    if (bottomNeighbor.TryGetComponent(out IDie die))
        //    {
        //        die.Died += OnBottomNeighborDie;
        //    }
        //}

        public void TakeDamage(int damage)
        {
            Health.TakeDamage(damage);
        }
        
        private void OnDied()
        {
            Died?.Invoke();
            Health.Died -= OnDied;
            Died = null;

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
            if (Rigidbody != null)
            {
                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
                Rigidbody.gravityScale = 1;
            }
        }
    }
}