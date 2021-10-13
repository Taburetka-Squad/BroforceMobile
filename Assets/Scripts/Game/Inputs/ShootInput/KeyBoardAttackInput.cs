using System;
using Game.Inputs.ShootInput;
using UnityEngine;

namespace Game.Inputs
{
    public class KeyBoardAttackInput : IAttackInput
    {
        public event Action Shot;

        public void ReadInput()
        {
            
        }
    }
}