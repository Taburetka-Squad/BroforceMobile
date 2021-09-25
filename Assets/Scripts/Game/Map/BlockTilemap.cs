using UnityEngine;

using Game.Map.Tiles;

namespace Game.Map
{
    public class BlockTilemap : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UnityEngine.Tilemaps.Tilemap _tilemap;

        private void Start()
        {
            SpawnBlocks();
        }

        private void SpawnBlocks()
        {
            foreach (var localPosition in _tilemap.cellBounds.allPositionsWithin)
            {
                var tile = GetTile(localPosition);
                if (tile == null) continue;

                SpawnBlock(tile, localPosition);
            }
        }
        public void SpawnBlock(BlockTile tile, Vector3Int localPosition)
        {
            var position = _tilemap.CellToWorld(localPosition);
            var rotation = _tilemap.GetTransformMatrix(localPosition).rotation;

            tile.SpawnBlock(position, rotation, transform);

            RemoveTile(localPosition);
        }

        private BlockTile GetTile(Vector3Int localPosition)
        {
            return _tilemap.GetTile<BlockTile>(localPosition);
        }
        private void RemoveTile(Vector3Int localPosition)
        {
            _tilemap.SetTile(localPosition, null);
        }

        public Vector2 GetTileCenter(Vector2 position)
        {
            return new Vector2(position.x + 0.5f, position.y + 0.5f);
        }
        public Vector2 GetTilePosition(Vector2 position)
        {
            var ceiledPosition = Vector2Int.CeilToInt(position);

            ceiledPosition.x -= 1;
            ceiledPosition.y -= 1;

            return ceiledPosition; // (Vector2Int)_tilemap.WorldToCell(worldPosition);
        }
    }
}