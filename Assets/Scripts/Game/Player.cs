using UnityEngine;

namespace Game
{
    class Player : Entity
    {
        // Input

        private void Update()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var canJump = Input.GetKeyDown(KeyCode.Space);
            //var canShoot = Input.GetMouseButtonDown(0) && WeaponSlot.HasWeapon;

            Move(horizontalDirection);

            if (canJump)
                Jump();

            if (false)
                WeaponSlot.CurrentWeapon.Shoot();
        }
    }
}