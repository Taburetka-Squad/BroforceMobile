using System;

namespace Game.Inputs
{
    public interface IMeleeAttackInput : IInput
    {
        event Action MeleeAttackUsed;
    }
}