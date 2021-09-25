#if UNITY_EDITOR
using UnityEngine;

using Game.Map.Tiles;
using Game.Map.Blocks;

namespace Game.Map
{
    public class MouseBlockDestroyer : MonoBehaviour
    {
        [SerializeField] private BlockTilemap _tilemap;
        [SerializeField] private BlockTile _placingTileBlock;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                DestroyBlock();
            if (Input.GetMouseButtonDown(1))
                PlaceBlock();
        }

        private void PlaceBlock()
        {
            var position = GetTilePositionByMouse();

            if (TryRaycastBlock(position, out var block))
                DestroyBlock(block);

            PlaceBlock(position, _placingTileBlock);
        }
        private void PlaceBlock(Vector2 position, BlockTile tile)
        {
            var tilePosition = new Vector3Int((int)position.x, (int)position.y, 0);
            _tilemap.SpawnBlock(tile, tilePosition);
        }

        private void DestroyBlock()
        {
            var position = GetTilePositionByMouse();

            if (TryRaycastBlock(position, out var block))
                DestroyBlock(block);
        }
        private void DestroyBlock(Block block)
        {
            Destroy(block.gameObject);
        }

        private Vector2 GetTilePositionByMouse()
        {
            var screenPosition = Input.mousePosition;
            var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            var cellPosition = _tilemap.GetTilePosition(worldPosition);

            return cellPosition;
        }
        private bool TryRaycastBlock(Vector2 position, out Block block)
        {
            block = null;

            var collider = Physics2D.OverlapPoint(position);
            if (collider == null) return false;

            return collider.TryGetComponent(out block);
        }
    }
}
#endif