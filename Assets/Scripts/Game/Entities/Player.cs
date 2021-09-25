using UnityEngine;
using Sirenix.OdinInspector;
using Game.Abilities;

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

            Rotate(horizontalDirection);
            Move(horizontalDirection);

            if (canJump)
                Jump();
            else Slide();

            if (canShoot)
                WeaponSlot.CurrentWeapon.Shoot();

            if (Input.GetKeyDown(KeyCode.Mouse1))
                _ability.Use(transform);
        }
    }
}