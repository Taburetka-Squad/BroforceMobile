using Game.Healths;
using UnityEngine;

namespace Game.Abilities
{
    public class ExplodeAmmo : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _explosionRadius;
        [SerializeField] private int _damageAmount;
        
        private void Explode()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Health.TakeDamage(_damageAmount);
                }
            }
            
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Explode();
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
#endif
    }
}