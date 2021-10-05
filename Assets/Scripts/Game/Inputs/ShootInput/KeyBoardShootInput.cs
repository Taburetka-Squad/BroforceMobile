using Game.Inputs.ShootInput;
using UnityEngine;

namespace Game.Inputs
{
    public class KeyBoardShootInput : IShootInput
    {
        public bool CanShoot => Input.GetKey(KeyCode.Mouse0);
    }
}