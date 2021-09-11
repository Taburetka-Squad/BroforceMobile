using UnityEngine;
using UnityEngine.Tilemaps;

using Sirenix.OdinInspector;

using Game.Map.Tiles.Effectors;

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
        [SerializeField] private TileEffector[] _destroyEffectors;

        public void DestroyIn(BlockTilemap tilemap, Vector2Int position)
        {
            if (_canDestroy == false) return;

            tilemap.SetEmptyIn(position);
            var blockCenter = tilemap.GetTileCenter(position);

            SpawnDestroyEffectors(tilemap, blockCenter);
            TryDestroyUpBlock(tilemap, position);
        }
        private void SpawnDestroyEffectors(BlockTilemap tilemap, Vector2 position)
        {
            foreach (var effector in _destroyEffectors)
                effector.Spawn(tilemap, this, position);
        }
        private void TryDestroyUpBlock(BlockTilemap tilemap, Vector2Int position)
        {
            var randomNumber = Random.Range(0f,  100f);
            if (randomNumber <= _chanceToDestroyUpBlock)
                tilemap.DestroyIn(position + Vector2Int.up);
        }
    }
}