using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

using Game.Map.Blocks;
using Game.Map.Tiles;

namespace Game.Map
{
    public class BlockTilemap : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Tilemap _tilemap;

        private List<Block> _blocks;

        private void Start()
        {
            _blocks = new List<Block>();
            Initialize();
        }

        private void Initialize()
        {
            SpawnBlocks();
            //foreach (var block in _blocks)
            //{
            //    block.OnMapInitialized();
            //}
        }

        private void SpawnBlocks()
        {
            foreach (var localPosition in _tilemap.cellBounds.allPositionsWithin)
            {
                var tile = GetTile(localPosition);
                if (tile == null) continue;

                var block = SpawnBlock(tile, localPosition);
                _blocks.Add(block);
            }
        }
        public Block SpawnBlock(BlockTile tile, Vector3Int localPosition)
        {
            var position = _tilemap.GetCellCenterWorld(localPosition);
            var rotation = _tilemap.GetTransformMatrix(localPosition).rotation;

            var block = tile.SpawnBlock(position, rotation, transform);

            RemoveTile(localPosition);
            return block;
        }

        private BlockTile GetTile(Vector3Int localPosition)
        {
            return _tilemap.GetTile<BlockTile>(localPosition);
        }
        private void RemoveTile(Vector3Int localPosition)
        {
            _tilemap.SetTile(localPosition, null);
        }

        public Vector2 GetTilePosition(Vector2 position)
        {
            var center = GetTileCenter(position);

            return (Vector2Int) _tilemap.WorldToCell(center);
        }
        public Vector2 GetTileCenter(Vector2 position)
        {
            return new Vector2(position.x + 0.5f, position.y + 0.5f);
        }
    }
}