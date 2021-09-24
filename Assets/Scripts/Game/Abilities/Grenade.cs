using UnityEngine;

namespace Game.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Grenade : ExplodeAmmo
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }
        
        public void Throw(Vector3 direction, float force)
        {
            _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}