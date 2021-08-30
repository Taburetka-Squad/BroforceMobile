using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    abstract class Entity : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected void Move(float direction)
        {
            // TODO
        }
        protected void Jump()
        {
            // TODO
        }
    }
}