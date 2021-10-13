using Game.Abilities;
using Game.Entities.ArmedEntities;
using UnityEngine;

namespace Game.Entities
{
    public class Bro : ArmedEntity
    {
        private const float WallCheckDistance = 0.52f;
        
        private IAttack _meleeAttack;

        private IAbility _ability;

        private float _slideSpeed;
        private Vector2 _direction;

        protected override bool CanJump =>
            DirectionInput.Direction.x != 0
            && IsTouchingWall()
            || GroundCollider.IsTouchingLayers();

        public void Initialize(BroData data)
        {
            base.Initialize(data);

            _meleeAttack = data.Attack.GetInstance(transform);
            _ability = data.Ability;
            _slideSpeed = data.SlideSpeed;
        }

        private void UseAbility()
        {
            _ability.Use(transform);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            _direction = DirectionInput.Direction;
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                _meleeAttack.Attack();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse1))
            {
                UseAbility();
            }
        }

        private void FixedUpdate()
        {
            Move(_direction);
            Rotate(_direction);

            if (DirectionInput.Direction.y > 0)
                Jump();
            else
                Slide(_direction);
        }

        private bool IsTouchingWall()
        {
            var direction = transform.right;

            var raycast = Physics2D.Raycast(transform.position, direction, WallCheckDistance);
            return raycast;
        }

        private void Slide(Vector2 direction)
        {
            var canSlide = IsTouchingWall() && Rigidbody.velocity.y < _slideSpeed && direction.x != 0;
            if (canSlide) Rigidbody.velocity = new Vector2(0, _slideSpeed);
        }
    }
}