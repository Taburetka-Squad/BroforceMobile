using UnityEngine;

namespace Game.Map.Tiles.Effectors
{
    abstract class TileEffector : ScriptableObject
    {
        public abstract void SpawnIn(Vector2 position);
    }
}