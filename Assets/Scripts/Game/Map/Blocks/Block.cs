using UnityEngine;

namespace Game.Map.Blocks
{
    [RequireComponent(typeof(SpriteRenderer)),
     RequireComponent(typeof(Rigidbody2D)),
     RequireComponent(typeof(BoxCollider2D))]
    public abstract class Block : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        protected Rigidbody2D Rigidbody2D;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public abstract void OnMapInitialized();
        
        public void Initialize(Sprite sprite, Color color)
        {
            _renderer.sprite = sprite;
            _renderer.color = color;
        }
    }
}