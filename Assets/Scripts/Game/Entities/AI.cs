using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    public class AI : Entity
    {
        [SerializeField] private float _viewDistance;

        private States _state;

        protected override bool CanJump { get; }

        private void Awake()
        {
            _state = States.Idle;
        }

        public override void TakeDamage(int damage)
        {
            
        }
        protected override void OnDied()
        {
            
        }

        private void CheckEnemy()
        {
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, _viewDistance);
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, _viewDistance);


        }
        private bool IsEnemy(RaycastHit2D hit)
        {
            if(hit.collider != null && hit.collider.gameObject.TryGetComponent(out Player player))
            {
                return true;
            }

            return false;
        }
    }

    enum States
    {
        Idle,
        Attack
    }
}