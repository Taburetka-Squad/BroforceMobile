using System;
using Cinemachine;
using Game.Entities;
using Game.Healths;
using Game.Levels;

namespace Game
{
    public class Player
    {
        public event Action BroDied;

        public Bro CurrentBro { get; private set; }

        private readonly Level _level;
        private readonly BroFactory _broFactory;
        private readonly CinemachineVirtualCamera _cinemachine;

        private int _currentLives;

        public Player(int currentLives, Level level, BroFactory broFactory, CinemachineVirtualCamera cinemachine)
        {
            _currentLives = currentLives;
            _broFactory = broFactory;
            _cinemachine = cinemachine;
            _level = level;

            SpawnBro();
        }

        private void SpawnBro()
        {
            CurrentBro = _broFactory.GetRandomBro();
            _level.MoveToLastCheckPoint(CurrentBro.transform);

            _cinemachine.Follow = CurrentBro.transform;

            CurrentBro.gameObject.GetComponent<Health>().Died += OnDied;
        }

        private void OnDied()
        {
            _currentLives -= 1;
            CurrentBro.gameObject.GetComponent<Health>().Died -= OnDied;

            SpawnBro();
            
            if (_currentLives <= 0)
            {
                BroDied?.Invoke();
            }
        }
    }
}