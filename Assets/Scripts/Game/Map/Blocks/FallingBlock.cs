using UnityEngine;

using Game.Map.Tiles;

namespace Game.Map.Blocks
{
    class FallingBlock : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        private BlockTilemap _tilemap;
        private SmartTile _tile;

        public void Initialize(BlockTilemap tilemap, SmartTile tile)
        {
            _tilemap = tilemap;
            _tile = tile;

            _renderer.sprite = tile.sprite;
            _renderer.color = tile.color;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Destroy(gameObject);

            var tilePosition = _tilemap.GetTilePositionFromCenter(transform.position);
            _tilemap.SetIn(tilePosition, _tile);
        }
    }
}