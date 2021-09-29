using System;

namespace Game.Inputs
{
    public interface IAbilityInput : IInput
    {
        event Action AbilityUsed;
    }
}