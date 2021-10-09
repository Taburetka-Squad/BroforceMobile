using Game.Healths;
using UnityEngine;

namespace Game.Map.Blocks
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]

    public abstract class Block : MonoBehaviour, IDamageable
    {
        public Health Health { get; private set; }
        [SerializeField] private int _startHitPoints;
        
        private SpriteRenderer _renderer;
        protected Rigidbody2D Rigidbody2D;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
        
            Health = new Health(_startHitPoints);
            Health.Died += OnDied;
        }
        
        public abstract void OnMapInitialized();
        public void Initialize(Sprite sprite, Color color)
        {
            _renderer.sprite = sprite;
            _renderer.color = color;
        }

        private void OnDied()
        {
            Health.Died -= OnDied;
            Die();
        }
        protected abstract void Die();
    }
}