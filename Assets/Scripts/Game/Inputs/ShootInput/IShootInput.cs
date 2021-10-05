using System;


namespace Game.Inputs.ShootInput
{
    public interface IShootInput : IInput
    {
        public bool CanShoot { get; }
        event Action Shot;
    }
}