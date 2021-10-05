﻿using Game.Inputs;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IDirectionInput : IInput
    {
        Vector2 Direction { get; }
    }
}