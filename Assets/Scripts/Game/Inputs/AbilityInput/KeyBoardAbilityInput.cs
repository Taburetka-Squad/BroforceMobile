using System;
using UnityEngine;

namespace Game.Inputs
{
    public class KeyBoardAbilityInput : IAbilityInput
    {
        public event Action AbilityUsed;
        
        public void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                AbilityUsed?.Invoke();
        }
    }
}