using Game.Map.Blocks;
using UnityEngine;

namespace Game.Map.Tiles.Effects
{
    [CreateAssetMenu(menuName = "Game/Tiles/Effectors/Falling")]
    class FallingBlockEffect : TileEffect
    {
        [SerializeField] private FallingBlock _prefab;

        public override void Spawn(BlockTilemap tilemap, SmartTile tile, Vector2 position)
        {
            var block = Instantiate(_prefab, position, Quaternion.identity);
            block.Initialize(tilemap, tile);
        }
    }
}