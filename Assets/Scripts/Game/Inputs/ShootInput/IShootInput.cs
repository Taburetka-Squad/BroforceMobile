using System;


namespace Game.Inputs.ShootInput
{
    public interface IShootInput
    {
        public bool CanShoot { get; }
        event Action Shot;
    }
}