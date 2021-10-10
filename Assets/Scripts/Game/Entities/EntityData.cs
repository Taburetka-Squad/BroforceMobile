using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EntityData/EntityData", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float JumpDelay => _jumpDelay;
        public int BaseHitPoints => _baseHitPoints;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpDelay;
        [SerializeField] private int _baseHitPoints;
        [SerializeField] private Entity _entityPrefab;
    }
}