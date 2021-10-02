using System;
using UnityEngine;

namespace Game.Inputs
{
    public class KeyBoardShootInput : IShootInput
    {
        public event Action Shot;
        
        public void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Shot?.Invoke();
        }
    }
}