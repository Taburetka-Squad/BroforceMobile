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
            var worldMousePositionCeiled = Vector2Int.CeilToInt(worldMousePosition);

            worldMousePositionCeiled.x -= 1;
            worldMousePositionCeiled.y -= 1;

            return worldMousePositionCeiled;
        }
        private void DestroyBlock(Vector2Int position)
        {
            _tilemap.DestroyIn(position);
        }
        private void PlaceBlock(Vector2Int position, SmartTile block)
        {
            _tilemap.SetIn(position, block, false);
        }
    }
}