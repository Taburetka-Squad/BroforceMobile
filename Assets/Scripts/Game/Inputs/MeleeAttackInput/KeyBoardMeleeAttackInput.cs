using System;
using UnityEngine;

namespace Game.Inputs
{
    public class KeyBoardMeleeAttackInput : IMeleeAttackInput
    {
        public event Action MeleeAttackUsed;
        
        public void ReadInput()
        {
            if (Input.GetKey(KeyCode.Q))
                MeleeAttackUsed?.Invoke();
        }
    }
}