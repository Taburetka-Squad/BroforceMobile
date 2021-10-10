using System;

namespace Game.Map.Blocks
{
    public interface IFall
    {
        event Action Fell;
    }
}