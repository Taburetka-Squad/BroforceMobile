using System;
using System.Collections.Generic;
using Game.Map;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Levels
{
    public class GameMap : MonoBehaviour
    {
        public event Action MapPassed;

        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private SpawnPoint _playerSpawnPoint;

        private SpawnPoint[] _enemiesSpawnPoints;
        [SerializeField] private CheckPoint[] _checkPoints;

        private CheckPoint _lastPassedCheckPoint;
        private BlockTilemap _blockTilemap;

        public void Initialzie()
        {
            _blockTilemap = new BlockTilemap(_tilemap, transform);

            foreach (var checkPoint in _checkPoints)
            {
                checkPoint.Reached += OnCheckPointReached;
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
            var spawnPoints = new List<SpawnPoint>();

            spawnPoints.AddRange(FindObjectsOfType<SpawnPoint>());

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                if (spawnPoints[i] == _playerSpawnPoint)
                {
                    spawnPoints.RemoveAt(i);
                }
            }

            _enemiesSpawnPoints = spawnPoints.ToArray();
        }
#endif

        #endregion
    }
}