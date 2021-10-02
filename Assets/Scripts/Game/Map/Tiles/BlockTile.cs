using Game.Map.Blocks;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Map.Tiles
{
    [CreateAssetMenu(menuName = "Game/Tiles/BlockTile")]
    public class BlockTile : Tile
    {
        [SerializeField] private Block _prefab;

        public Block SpawnBlock(Vector2 position, Quaternion rotation)
        {
            var block = Instantiate(_prefab, position, rotation);
            block.Initialize(sprite, color);
            return block;
        }
    }
}