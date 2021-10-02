using System.Collections.Generic;
using Game.Map;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Levels
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private SpawnPoint _playerSpawnPoint;

        private SpawnPoint[] _enemiesSpawnPoints;
        private CheckPoint[] _checkPoints;

        private CheckPoint _lastPassedCheckPoint;
        private BlockTilemap _blockTilemap;

        public void Initialzie()
        {
            _blockTilemap = new BlockTilemap(_tilemap);

            foreach (var checkPoint in _checkPoints)
            {
                checkPoint.Reached += OnCheckPointReached;
            }
        }

        private void OnCheckPointReached(CheckPoint checkPoint)
        {
            _lastPassedCheckPoint = checkPoint;
        }


#if UNITY_EDITOR
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
    }
}