using Game.Abilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Entities
{
    class Player : Entity
    {
        [ShowInInspector] private IAbility _ability;
        
        public override void TakeDamage(int damage)
        {
           _health.TakeDamage(damage);
        }
        
        protected override void OnDied()
        {
            Debug.Log("Player Died");
        }
        
        // Input
        private void Update()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var canJump = Input.GetKeyDown(KeyCode.Space);
            var canShoot = Input.GetMouseButton(0) && WeaponSlot.HasWeapon;

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _ability.Use(transform);
            }

            Rotate(horizontalDirection);
            Move(horizontalDirection);

            if (canJump)
                Jump();

            if (canShoot)
                WeaponSlot.CurrentWeapon.Shoot();
            
        }
        
        private void Rotate(float direction)
        {
            if (direction == 1)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (direction == -1)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }

    }
}