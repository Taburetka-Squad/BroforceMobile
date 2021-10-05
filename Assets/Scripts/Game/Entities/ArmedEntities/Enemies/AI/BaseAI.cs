using System.Collections;
using Game.Entities.ArmedEntities;
using UnityEngine;

namespace Game.Entities
{
    public abstract class BaseAI : ArmedEntity
    {
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _startFireDelay;

        protected abstract void React();
        
        protected bool IsPlayer(RaycastHit2D hit)
        {
            return hit.collider.TryGetComponent(out Bro bro);
        }
        protected RaycastHit2D Look()
        {
            return Physics2D.Raycast(transform.position, Vector2.right, _viewDistance);
        }
        protected IEnumerator Fire()
        {
            yield return new WaitForSeconds(_startFireDelay);

            Shoot();
        }
    }
}
