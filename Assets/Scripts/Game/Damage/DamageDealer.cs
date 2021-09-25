using UnityEngine;

namespace Game.Damage
{
    public class DamageDealer : MonoBehaviour
    {
        private int _damageAmount;

        public void Initialize(int damageAmount)
        {
            _damageAmount = damageAmount;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damageAmount);
        }
    }
}