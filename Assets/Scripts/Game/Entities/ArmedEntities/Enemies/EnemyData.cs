using Game.Entities.ArmedEntities;
using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EnemyData", order = 0)]
    public class EnemyData : ArmedEntityData
    {
        public EnemyType EnemyType => _enemyType;

        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private Enemy _prefab;
        
        public Enemy CreateInstance()
        {
            var instance = Instantiate(_prefab);
            instance.Initialize(this);
            return instance;
        }
    }
}