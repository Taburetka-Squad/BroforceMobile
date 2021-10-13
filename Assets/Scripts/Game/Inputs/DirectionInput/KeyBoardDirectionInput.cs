using UnityEngine;

namespace Game.Inputs.DirectionInput
{
    public class KeyBoardDirectionInput : IDirectionInput
    {
        public Vector2 Direction { get; private set; }
        
        public void ReadInput()
        {
            var horizontalDirection = UnityEngine.Input.GetAxisRaw("Horizontal");
            var verticalDirection = UnityEngine.Input.GetAxisRaw("Vertical");

            Direction = new Vector2(horizontalDirection, verticalDirection);
        }
    }
}