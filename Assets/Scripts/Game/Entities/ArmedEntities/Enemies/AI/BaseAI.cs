using Game.Entities.ArmedEntities;
using UnityEngine;

namespace Game.Entities
{
    public abstract class BaseAI : Enemy
    {
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _startFireDelay;
        [SerializeField] private ArmedEntityData _data;

        private void Start()
        {
            Initialize(_data);
        }

        protected abstract bool React();
        
        protected bool IsPlayer(RaycastHit2D hit)
        {
            return hit.collider.TryGetComponent(out Bro player);
        }
        protected RaycastHit2D Look()
        {
            return Physics2D.Raycast(transform.position, Vector2.right, _viewDistance);
        }
        protected void Fire()
        {
            Attack();
        }
    }
}
