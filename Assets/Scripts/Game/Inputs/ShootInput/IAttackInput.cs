using System;

namespace Game.Inputs.ShootInput
{
    public interface IAttackInput : IInput
    {
        event Action Shot;
    }
}