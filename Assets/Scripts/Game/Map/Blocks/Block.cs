using UnityEngine;

namespace Game.Map.Blocks
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Block : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;
        private SpriteRenderer _renderer;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void InitializeVisual(Sprite sprite, Color color)
        {
            _renderer.sprite = sprite;
            _renderer.color = color;
        }
    }
}