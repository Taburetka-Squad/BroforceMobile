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
        
        public BlockTilemap(Tilemap tilemap)
        {
            _blocks = new List<Block>();
            
            SpawnBlocks(tilemap);
            
            foreach (var block in _blocks)
            {
                block.OnMapInitialized();
            }
        }

        private void SpawnBlocks(Tilemap tilemap)
        {
            foreach (var localPosition in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = GetTile(localPosition, tilemap);
                if (tile == null) continue;

                var block = SpawnBlock(tile, localPosition, tilemap);
                _blocks.Add(block);
            }
        }

        public Block SpawnBlock(BlockTile tile, Vector3Int localPosition, Tilemap tilemap)
        {
            var position = tilemap.CellToWorld(localPosition);
            var rotation = tilemap.GetTransformMatrix(localPosition).rotation;

            var block = tile.SpawnBlock(position, rotation);

            RemoveTile(localPosition, tilemap);
            return block;
        }

        private BlockTile GetTile(Vector3Int localPosition, Tilemap tilemap)
        {
            return tilemap.GetTile<BlockTile>(localPosition);
        }

        private void RemoveTile(Vector3Int localPosition, Tilemap tilemap)
        {
            tilemap.SetTile(localPosition, null);
        }

        public Vector2 GetTilePosition(Vector2 position, Tilemap tilemap)
        {
            var center = GetTileCenter(position);

            return (Vector2Int) tilemap.WorldToCell(center);
        }

        public Vector2 GetTileCenter(Vector2 position)
        {
            return new Vector2(position.x + 0.5f, position.y + 0.5f);
        }
    }
}