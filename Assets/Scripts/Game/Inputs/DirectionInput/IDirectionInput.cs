using UnityEngine;

namespace Game.Inputs.DirectionInput
{
    public interface IDirectionInput : IInput
    {
        Vector2 Direction { get; }
    }
}