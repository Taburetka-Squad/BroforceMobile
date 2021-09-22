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
            var canShoot = Input.GetMouseButton(0) && WeaponSlot.HasWeapon;

            Rotate(horizontalDirection);
            Move(horizontalDirection);

            if (canJump)
                Jump();

            if (canShoot)
                WeaponSlot.CurrentWeapon.Shoot();
        }
    }
}