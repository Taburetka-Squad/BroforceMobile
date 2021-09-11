using UnityEngine;

namespace Game.Map.Tiles.Effectors
{
    abstract class TileEffect : ScriptableObject
    {
        public abstract void Spawn(BlockTilemap tilemap, SmartTile tile, Vector2 position);
    }
}