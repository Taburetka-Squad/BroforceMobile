using UnityEngine;

using Game.Map.Blocks;

namespace Game.Map.Tiles.Effectors
{
    [CreateAssetMenu(menuName = "Game/Tiles/Effectors/Falling")]
    class FallingBlockEffector : TileEffector
    {
        [SerializeField] private FallingBlock _prefab;

        public override void Spawn(BlockTilemap tilemap, SmartTile tile, Vector2 position)
        {
            var block = Instantiate(_prefab, position, Quaternion.identity);
            block.Initialize(tilemap, tile);
        }
    }
}