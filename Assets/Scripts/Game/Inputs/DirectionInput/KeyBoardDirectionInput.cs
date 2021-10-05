using DefaultNamespace;
using UnityEngine;

namespace Game.Inputs.DirectionInput
{
    public class KeyBoardDirectionInput : IDirectionInput
    {
        public Vector2 Direction => 
            new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }
}