using UnityEngine;

namespace DefaultNamespace
{
    public class KeyBoardDirectionInput : IDirectionInput
    {
        public Vector2 Direction { get; private set; }

        public void ReadInput()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var verticalDirection = Input.GetAxisRaw("Vertical");
            
            Direction = new Vector2(horizontalDirection,verticalDirection);
        }
    }
}