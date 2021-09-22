using UnityEngine;

using Game.Map.Tiles;

namespace Game.Map
{
    public class MouseBlockDestroyer : MonoBehaviour
    {
        [SerializeField] private BlockTilemap _tilemap;
        [SerializeField] private SmartTile _placeBlock;

        private void Update()
        {
            if (Input.GetMouseButton(0))
                DestroyBlock();
            else if (Input.GetMouseButton(1))
                PlaceBlock();
        }

        private void DestroyBlock()
        {
            var tilePosition = GetTilePositionByMouse();
            DestroyBlock(tilePosition);
        }
        private void PlaceBlock()
        {
            var tilePosition = GetTilePositionByMouse();
            PlaceBlock(tilePosition, _placeBlock);
        }

        private Vector2Int GetTilePositionByMouse()
        {
            var mouseScreenPosition = Input.mousePosition;
            var worldMousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            return _tilemap.GetTilePositionFromCenter(worldMousePosition);
        }
        private void DestroyBlock(Vector2Int position)
        {
            _tilemap.DestroyAt(position);
        }
        private void PlaceBlock(Vector2Int position, SmartTile block)
        {
            _tilemap.SetAt(position, block);
        }
    }
}