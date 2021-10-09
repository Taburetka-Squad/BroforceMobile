using System;
using Cinemachine;
using Game.Entities;
using Game.Levels;
using Object = UnityEngine.Object;

namespace Game
{
    public class Player : IDisposable
    {
        public event Action BroDied;

        private Bro _currentBro;

        private GameMap _gameMap;
        private BroFactory _broFactory;
        private CinemachineVirtualCamera _cinemachine;

        private int _currentLives;

        public Player(int currentLives, GameMap gameMap, BroFactory broFactory, CinemachineVirtualCamera cinemachine)
        {
            _currentLives = currentLives;
            _broFactory = broFactory;
            _cinemachine = cinemachine;
            _gameMap = gameMap;

            SpawnBro();
        }

        private void SpawnBro()
        {
            _currentBro = _broFactory.GetRandomBro();
            _gameMap.MoveToLastCheckPoint(_currentBro.transform);

            _cinemachine.Follow = _currentBro.transform;

            _currentBro.Health.Died += OnDied;
        }

        private void OnDied()
        {
            _currentLives -= 1;
            _currentBro.Health.Died -= OnDied;

            SpawnBro();
            
            if (_currentLives <= 0)
            {
                BroDied?.Invoke();
            }
        }

        public void Dispose()
        {
            BroDied = null;
            _currentBro.Health.Died -= OnDied;
            Object.Destroy(_currentBro.gameObject);
        }
    }
}