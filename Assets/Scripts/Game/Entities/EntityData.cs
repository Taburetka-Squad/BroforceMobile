using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData/EntityData", order = 0)]
    public abstract class EntityData : ScriptableObject
    {
        public abstract Entity Prefab { get; }

        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float JumpDelay => _jumpDelay;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpDelay;

        public Entity CreateInstance()
        {
            var instance = Instantiate(Prefab);
            instance.Initialize(this);
            return instance;
        }
    }
}