using UnityEngine;

namespace Game.Map.Blocks
{
    [CreateAssetMenu(fileName = "Game/BlockTiles/Sand")]
    public class SandBlockData : BlockData<Sand>
    {
        protected override Sand Prefab { get; }

        protected override void Initialize(Sand block)
        {
            
        }
    }
}