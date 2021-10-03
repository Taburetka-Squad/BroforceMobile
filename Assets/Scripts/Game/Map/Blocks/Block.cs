using Game.Healths;
using UnityEngine;

namespace Game.Map.Blocks
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Health))]

    public abstract class Block : MonoBehaviour
    {
        private Health _health;
        private SpriteRenderer _renderer;
        protected Rigidbody2D Rigidbody2D;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _health = GetComponent<Health>();
            _health.Died += OnDied;
        }
        
        public abstract void OnMapInitialized();
        public void Initialize(Sprite sprite, Color color)
        {
            _renderer.sprite = sprite;
            _renderer.color = color;
        }

        private void OnDied()
        {
            _health.Died -= OnDied;
            Die();
        }
        protected abstract void Die();
    }
}