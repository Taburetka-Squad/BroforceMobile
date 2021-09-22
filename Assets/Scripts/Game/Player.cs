using Game.Abilities;
using UnityEngine;

namespace Game
{
    class Player : Entity
    {
        private IAbility _ability;
        
        // Input
        private void Update()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var canJump = Input.GetKeyDown(KeyCode.Space);
            var canShoot = Input.GetMouseButton(0) && WeaponSlot.HasWeapon;

            if (Input.GetKey(KeyCode.Mouse1))
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