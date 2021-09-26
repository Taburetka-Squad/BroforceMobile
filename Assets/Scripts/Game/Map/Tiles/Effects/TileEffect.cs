using UnityEngine;

namespace Game.Map.Tiles.Effects
{
    abstract class TileEffect : ScriptableObject
    {
        public abstract void Spawn(BlockTilemap tilemap, BlockTile tile, Vector2 position);
    }
}