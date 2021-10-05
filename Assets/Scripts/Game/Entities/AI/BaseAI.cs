using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    public abstract class BaseAI : Entity
    {
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _startFireDelay;

        protected virtual void React()
        {
            var result = Look();
            var canFire = result.collider != null && IsPlayer(result);

            if (canFire)
                StartCoroutine(Fire());
        }
        protected bool IsPlayer(RaycastHit2D hit)
        {
            return hit.collider.TryGetComponent(out Player player);
        }
        protected RaycastHit2D Look()
        {
            return Physics2D.Raycast(transform.position, Vector2.right, _viewDistance);
        }
        protected IEnumerator Fire()
        {
            yield return new WaitForSeconds(_startFireDelay);

            WeaponSlot.CurrentWeapon.Shoot();
        }
    }
}
