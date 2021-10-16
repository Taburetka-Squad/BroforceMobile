using UnityEngine;
using System.Collections;
using Game.Entities.ArmedEntities;
using CleverCrow.Fluid.BTs.Trees;
using CleverCrow.Fluid.BTs.Tasks;

namespace Game.Entities
{
    public abstract class Enemy : ArmedEntity
    {
        // AI
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _startFireDelay;

        [SerializeField] protected ArmedEntityData _data;
        [SerializeField] protected BehaviorTree _tree;

        protected override bool CanJump => false;
        protected override void Die()
        {
            Debug.Log("Enemy Died");
            Destroy(gameObject);
        }

        private void Start()
        {
            Initialize(_data);
        }

        protected bool CanShoot()
        {
            var result = Look();
            return result.collider != null && IsPlayer(result);
        }
        protected TaskStatus Fire()
        {
            StartCoroutine(Shoot());
            return TaskStatus.Success;
        }

        private IEnumerator Shoot()
        {
            yield return new WaitForSeconds(_startFireDelay);
            Attack();
        }
        private bool IsPlayer(RaycastHit2D hit)
        {
            return hit.collider.TryGetComponent(out Bro bro);
        }
        private RaycastHit2D Look()
        {
            Debug.DrawRay(transform.position, transform.right * _viewDistance);
            return Physics2D.Raycast(transform.position, transform.right, _viewDistance);
        }
    }
}