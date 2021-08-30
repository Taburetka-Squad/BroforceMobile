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

            Move(horizontalDirection);
            if (canJump) Jump();
        }
    }
}