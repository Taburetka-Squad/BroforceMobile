using UnityEngine;

namespace Game.Map.Blocks
{
    public abstract class BlockData : ScriptableObject
    {
        public abstract Block CreateInstance(
            Vector2 position, Quaternion rotation,
            Transform container,
            Sprite sprite, Color color);
    }
    public abstract class BlockData<T> : ScriptableObject
        where T : Block
    {
        protected abstract T Prefab { get; }

        public Block CreateInstance(
            Vector2 position, Quaternion rotation,
            Transform container,
            Sprite sprite, Color color)
        {
            var block = Instantiate(Prefab, position, rotation, container);
            block.InitializeVisual(sprite, color);
            
            Initialize(block);

            return block;
        }

        protected abstract void Initialize(T block);
    }
}