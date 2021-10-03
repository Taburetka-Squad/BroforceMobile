using System.Collections;
using UnityEngine;

namespace Game.Entities
{
    public class DummyAI : Entity
    {
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _startFireDelay;
        [SerializeField] private float _fireDuration;

        private const int _right = 1;
        private const int _left = -1;

        protected override bool CanJump => false;

        private void Update()
        {
            React();
        }

        public override void TakeDamage(int damage) { }
        protected override void OnDied() { }

        private void React()
        {
            var rightRay = Physics2D.Raycast(transform.position, Vector2.right, _viewDistance);

            if (IsPlayer(rightRay))
                StartCoroutine(Fire());
        }
        private bool IsPlayer(RaycastHit2D hit)
        {
            if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
            {
                return true;
            }

            return false;
        }
        IEnumerator Fire()
        {
            yield return new WaitForSeconds(_startFireDelay);

            WeaponSlot.CurrentWeapon.Shoot();
        }
    }
}
