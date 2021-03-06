using UnityEngine;

namespace Game.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rocket : ExplodeAmmo
    {
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        public void Launch(Vector3 direction, float speed)
        {
            _rigidbody2D.AddForce(direction * speed, ForceMode2D.Impulse);
        }

    }
}