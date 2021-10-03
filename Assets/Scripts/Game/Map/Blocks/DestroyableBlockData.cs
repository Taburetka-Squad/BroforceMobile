using Game.Healths;

using UnityEngine;

namespace Game.Map.Blocks
{
    [CreateAssetMenu(fileName = "Game/BlockTiles/Destroyable")]
    public class DestroyableBlockData : BlockData<DestroyableBlock>
    {
        public HealthData Health => _health;

        [Header("References")]
        [SerializeField] private DestroyableBlock _prefab;
        [SerializeField] private HealthData _health;

        protected override DestroyableBlock Prefab => _prefab;
        protected override void Initialize(DestroyableBlock block)
        {
            block.Initialize(this);
        }
    }
}