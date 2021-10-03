using UnityEngine;

using Game.Healths;

namespace Game.Map.Blocks
{
    [RequireComponent(typeof(Health))]
    public class DestroyableBlock : Block
    {
        public void Initialize(DestroyableBlockData data)
        {
            
        }
    }
}