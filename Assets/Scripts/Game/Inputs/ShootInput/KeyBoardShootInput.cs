using System;
using Game.Inputs.ShootInput;
using UnityEngine;

namespace Game.Inputs
{
    public class KeyBoardShootInput : IShootInput
    {
        public event Action Shot;
        public bool CanShoot => Input.GetKey(KeyCode.Mouse0);
        public void ReadInput()
        {
            throw new NotImplementedException();
        }

    }
}