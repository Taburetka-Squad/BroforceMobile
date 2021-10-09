using System.Collections.Generic;
using Game.Map.Blocks;
using UnityEngine;
using Game.Map.Tiles;
using UnityEngine.Tilemaps;

namespace Game.Map
{
    public class BlockTilemap
    {
        private List<Block> _blocks;
        private Tilemap _tilemap;

        public BlockTilemap(Tilemap tilemap, Transform parent)
        {
            _tilemap = tilemap;

            SpawnBlocks(parent);

            foreach (var block in _blocks)
            {
                block.OnMapInitialized();
            }
        }

        private void SpawnBlocks(Transform parent)
        {
            _blocks = new List<Block>();
            
            foreach (var localPosition in _tilemap.cellBounds.allPositionsWithin)
            {
                var tile = GetTile(localPosition);
                if (tile == null) continue;

                var block = SpawnBlock(tile, localPosition);
                block.transform.parent = parent;
                
                _blocks.Add(block);
            }
        }

        public Block SpawnBlock(BlockTile tile, Vector3Int localPosition)
        {
            var position = _tilemap.CellToWorld(localPosition);
            var rotation = _tilemap.GetTransformMatrix(localPosition).rotation;

            var block = tile.SpawnBlock(position, rotation);

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