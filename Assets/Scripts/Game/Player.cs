using System;
using Game.Entities;
using Game.Healths;

namespace Game
{
    public class Player
    {
        public event Action BroDied;
        public Bro CurrentBro { get; }

        private int _currentLives;

        public Player(int currentLives, Bro bro)
        {
            _currentLives = currentLives;
            CurrentBro = bro;

            CurrentBro.gameObject.GetComponent<Health>().Died += OnDied;
        }

        private void OnDied()
        {
            _currentLives -= 1;
            CurrentBro.gameObject.GetComponent<Health>().Died -= OnDied;

            if (_currentLives <= 0)
            {
                BroDied?.Invoke();
            }
        }
    }
}