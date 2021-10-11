using System;
using Game.Entities;
using Game.Map;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Levels
{
    public class GameMap : MonoBehaviour
    {
        public event Action MapPassed;

        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private BroSpawnPoint _playerSpawnPoint;

        [SerializeField] private EnemySpawnPoint[] _enemiesSpawnPoints;
        [SerializeField] private CheckPoint[] _checkPoints;

        private CheckPoint _lastPassedCheckPoint;
        private BlockTilemap _blockTilemap;
       

        public void Initialzie(EnemyFactory enemyFactory)
        {
            SpawnEnemies(enemyFactory);

            _blockTilemap = new BlockTilemap(_tilemap, transform);

            foreach (var checkPoint in _checkPoints)
            {
                checkPoint.Reached += OnCheckPointReached;
            }
        }

        private void SpawnEnemies(EnemyFactory enemyFactory)
        {
            foreach (var enemiesSpawnPoint in _enemiesSpawnPoints)
            {
                var type = enemiesSpawnPoint.EnemyType;
                var enemy = enemyFactory.GetEnemy(type);
                
                enemiesSpawnPoint.MoveObjectToMe(enemy.transform);
                enemy.transform.SetParent(transform);
            }
        }

        private void OnCheckPointReached(CheckPoint checkPoint)
        {
            _lastPassedCheckPoint = checkPoint;

            if (checkPoint == _checkPoints[_checkPoints.Length - 1])
            {
                MapPassed?.Invoke();
            }
        }

        public void MoveToLastCheckPoint(Transform targetTransform)
        {
            if (_lastPassedCheckPoint != null)
            {
                _lastPassedCheckPoint.MoveObjectToMe(targetTransform);
                return;
            }

            _playerSpawnPoint.MoveObjectToMe(targetTransform);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        #region Editor

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (_checkPoints == null)
            {
                print("Не забудь заполнить массив чекпоинтов");
            }
        }

        [ContextMenu("FillCheckPointsArray")]
        private void FillCheckPointsArray()
        {
            _checkPoints = FindObjectsOfType<CheckPoint>();
        }

        [ContextMenu("FillEnemiesSpawnPointsArray")]
        private void FillEnemiesSpawnPointsArray()
        {
            _enemiesSpawnPoints = FindObjectsOfType<EnemySpawnPoint>();
        }
#endif

        #endregion
    }
}