﻿using DefaultNamespace;
using UnityEngine;

namespace Game.Inputs.DirectionInput
{
    public class KeyBoardDirectionInput : IDirectionInput
    {
        public Vector2 Direction {
            get
            {
                return new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            }
            private set
            {
            }
        }

        public void ReadInput()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var verticalDirection = Input.GetAxisRaw("Vertical");

            Direction = new Vector2(horizontalDirection, verticalDirection);
        }
    }
}