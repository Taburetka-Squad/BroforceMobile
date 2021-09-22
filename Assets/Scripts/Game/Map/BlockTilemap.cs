using UnityEngine;
using UnityEngine.Tilemaps;

using Game.Map.Tiles;

namespace Game.Map
{
    class BlockTilemap : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Tilemap _tilemap;

        public void DestroyAt(Vector2Int position)
        {
            if (TryGetTile(position, out SmartTile smartTile))
                smartTile.Destroy(this, position);
        }
        
        public void SetEmptyAt(Vector2Int position)
        {
            SetAt(position, null);
        }
        
        public void SetAt(Vector2Int position, SmartTile block)
        {
            _tilemap.SetTile((Vector3Int)position, block);
        }

        private bool TryGetTile<T>(Vector2Int position, out T tile) where T : TileBase
        {
            tile = GetTile<T>(position);

            return tile != null;
        }
        
        private T GetTile<T>(Vector2Int position) where T : TileBase
        {
            return _tilemap.GetTile<T>((Vector3Int)position);
        }

        public Vector2 GetTileCenter(Vector2Int position)
        {
            return new Vector2(position.x + 0.5f, position.y + 0.5f);
        }
        
        public Vector2Int GetTilePositionFromCenter(Vector2 position)
        {
            var ceiledPosition = Vector2Int.CeilToInt(position);

            ceiledPosition.x -= 1;
            ceiledPosition.y -= 1;

            return ceiledPosition;
        }
    }
}