using UnityEngine;
using UnityEngine.Tilemaps;

using Game.Map.Tiles.Effectors;

namespace Game.Map.Tiles
{
    [CreateAssetMenu(menuName = "Game/Tiles/SmartTile")]
    class SmartTile : Tile
    {
        [SerializeField] private TileEffector[] _effectors;

        public void DestroyIn(BlockTilemap tilemap, Vector2 position)
        {
            foreach (var effector in _effectors)
                effector.SpawnIn(position);

            Debug.Log("Destroyed");
        }
    }
}