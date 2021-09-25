using Game.Map.Blocks;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Map.Tiles
{
    [CreateAssetMenu(menuName = "Game/Tiles/BlockTile")]
    public class BlockTile : Tile
    {
        [SerializeField] private Block _prefab;

        public void SpawnBlock(Vector2 position, Quaternion rotation, Transform container)
        {
            var block = Instantiate(_prefab, position, rotation, container);
            block.Initialize(sprite, color);
        }
    }
}