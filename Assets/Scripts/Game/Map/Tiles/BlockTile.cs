using Game.Map.Blocks;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Map.Tiles
{
    [CreateAssetMenu(menuName = "Game/Tiles/BlockTile")]
    public class BlockTile : Tile
    {
        [Header("References")]
        [SerializeField] private BlockData _blockData;

        public Block SpawnBlock(Vector2 position, Quaternion rotation, Transform container)
        {
            return _blockData.CreateInstance(position, rotation, container, sprite, color);
        }
    }
}