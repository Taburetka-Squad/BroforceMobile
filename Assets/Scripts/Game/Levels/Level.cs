using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemachine;

namespace Game.Levels
{
    public class Level
    {
        public event Action LevelPassed;

        private LevelData _data;
        private Queue<GameMap> _gameMapPrefabs;
        private CinemachineVirtualCamera _cinemachine;

        private GameMap _currentGameMap;
        private Player _player;

        public Level(LevelData data, CinemachineVirtualCamera cinemachine)
        {
            _data = data;
            _cinemachine = cinemachine;

            Start();
        }

        private void Start()
        {
            _gameMapPrefabs = new Queue<GameMap>();

            foreach (var prefab in _data.GameMapPrefabs)
            {
                _gameMapPrefabs.Enqueue(prefab);
            }

            SwitchToNextMap();
        }

        private async void SwitchToNextMap()
        {
            if (_currentGameMap != null)
            {
                _currentGameMap.Destroy();
            }

            if (_gameMapPrefabs.Count > 0)
            {
                await Task.Delay(500);
                
                CreateCurrentMapInstance();
                _gameMapPrefabs.Dequeue();

                CreatePlayer();
                return;
            }

            LevelPassed?.Invoke();
        }

        private void CreateCurrentMapInstance()
        {
            var prefab = _gameMapPrefabs.Peek();

            _currentGameMap = _data.CreateMapInstance(prefab);
            _currentGameMap.MapPassed += OnMapPassed;
        }

        private void OnMapPassed()
        {
            _currentGameMap.MapPassed -= OnMapPassed;
            _player.Dispose();
            SwitchToNextMap();
        }

        private void CreatePlayer()
        {
            var map = _currentGameMap;
            var startLives = _data.StartCountPlayerLives;

            _player = new Player(startLives, map, _data.Factory, _cinemachine);
            _player.BroDied += OnBroDied;
        }

        private void OnBroDied()
        {
            _player.BroDied -= OnBroDied;
            Restart();
        }

        private void Restart()
        {
            _player.Dispose();
            Start();
        }
    }
}