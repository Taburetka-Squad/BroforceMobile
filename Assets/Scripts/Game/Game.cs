using Cinemachine;
using Game.Levels;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameDataFactory _gameDataFactory;
        [SerializeField] private CinemachineVirtualCamera _cinemachine;

        public void Start()
        {
            var data = _gameDataFactory.GetGameData(Difficulty.Easy);

            var level = new Level(data.LevelData, _cinemachine);
            level.LevelPassed += OnLevelPassed;
        }

        private void OnLevelPassed()
        {
            print("Level Complete");
        }
    }
}