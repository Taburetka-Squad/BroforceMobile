using System.Collections;
using UnityEngine;

namespace Game.Entities
{
    public class DummyAI : Entity
    {
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _startFireDelay;
        [SerializeField] private float _fireDuration;

        protected override bool CanJump => false;

        private void Update()
        {
            React();
        }

        protected override void Die()
        {
        }

        private void React()
        {
            var ray = Physics2D.Raycast(transform.position, Vector2.right, _viewDistance);
            if (ray.collider)
                return;
            
            if (IsPlayer(ray.collider))
                StartCoroutine(Fire());
        }

        private bool IsPlayer(Collider2D collider)
        {
            return collider.TryGetComponent(out Player _);
        }

        private IEnumerator Fire()
        {
            yield return new WaitForSeconds(_startFireDelay);

            WeaponSlot.CurrentWeapon.Shoot();
        }
    }
}