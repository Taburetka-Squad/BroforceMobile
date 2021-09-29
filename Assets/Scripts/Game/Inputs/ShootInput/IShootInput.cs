using System;

namespace Game.Inputs
{
    public interface IShootInput : IInput
    {
        event Action Shot;
    }
}