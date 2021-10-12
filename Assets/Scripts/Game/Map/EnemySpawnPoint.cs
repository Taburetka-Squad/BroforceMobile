using Game.Entities;
using UnityEngine;

namespace Game.Map
{
    public class EnemySpawnPoint : SpawnPoint
    {
        public EnemyType EnemyType => _enemyType;
        
        [SerializeField] private EnemyType _enemyType;

    }
}