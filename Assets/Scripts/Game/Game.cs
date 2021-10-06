using Cinemachine;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameDataFactory _gameDataFactory;
        [SerializeField] private CinemachineVirtualCamera _cinemachine;
        private Player _player;
        private GameData _data;
        
        public void Start()
        {
            _data = _gameDataFactory.GetGameData(Difficulty.Easy);
            
            var level = _data.CreateLevelInstance();

            _player = new Player(_data.StartCountPlayerLives, level, _data.Factory, _cinemachine);
            _player.BroDied += OnBroDied;
        }

        private void OnBroDied()
        {
            Debug.Log("Game Ended");
        }
    }
}