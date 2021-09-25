using UnityEngine;
using UnityEngine.Tilemaps;

using Sirenix.OdinInspector;

using Game.Health;
using Game.Map.Tiles.Effects;

namespace Game.Map.Tiles
{
    [CreateAssetMenu(menuName = "Game/Tiles/SmartTile")]
    class SmartTile : Tile
    {
        [Header("Destroy")]
        [SerializeField] private bool _canDestroy;
        [ShowIf(nameof(_canDestroy))]
        [SerializeField, Range(0, 100)] private int _chanceToDestroyUpBlock;
        [ShowIf(nameof(_canDestroy))]
        [SerializeField] private TileEffect[] _destroyEffects;

        [SerializeField] private HealthData _health;

        public void Destroy(BlockTilemap tilemap, Vector2Int position)
        {
            if (_canDestroy == false) return;

            tilemap.SetEmptyAt(position);
            var blockCenter = tilemap.GetTileCenter(position);

            SpawnDestroyEffects(tilemap, blockCenter);
            TryDestroyUpBlock(tilemap, position);
        }
        
        private void SpawnDestroyEffects(BlockTilemap tilemap, Vector2 position)
        {
            foreach (var effect in _destroyEffects)
                effect.Spawn(tilemap, this, position);
        }
        
        private void TryDestroyUpBlock(BlockTilemap tilemap, Vector2Int position)
        {
            var randomNumber = Random.Range(0f,  100f);
            if (randomNumber <= _chanceToDestroyUpBlock)
                tilemap.DestroyAt(position + Vector2Int.up);
            
            
            /*
            var blockCount = Random.Range(0, _blockCountToDestroy);
            var currentPosition = position;
            
            for (var i = 0; i < blockCount; i++)
            {
                currentPosition += Vector2Int.up;
                tilemap.DestroyAt(currentPosition);
                
            }
            */
        }

    }
}