using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData/EntityData", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float JumpDelay => _jumpDelay;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpDelay;
        [SerializeField] private Entity _entityPrefab;

        public Entity CreateInstance()
        {
            var instance = Instantiate(_entityPrefab);
            instance.Initialize(this);
            return instance;
        }
    }
}