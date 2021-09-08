using UnityEngine;
using UnityEngine.Tilemaps;

using Game.Map.Tiles;

namespace Game.Map
{
    class BlockTilemap : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Vector2Int _destroyPosition;

        [ContextMenu("DestroyTest")]
        public void DestroyTest()
        {
            DestroyIn(_destroyPosition);
        }

        public void DestroyIn(Vector2Int position)
        {
            if (TryGetTile(position, out SmartTile smartTile))
            {
                SetEmptyIn(position);
                smartTile.DestroyIn(this, new Vector2(position.x + 0.5f, position.y + 0.5f));
            }
        }
        public void SetEmptyIn(Vector2Int position, bool destroyBefore = false)
        {
            SetIn(position, null, destroyBefore);
        }
        public void SetIn(Vector2Int position, SmartTile block, bool destroyBefore = false)
        {
            if (destroyBefore) DestroyIn(position);

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
    }
}