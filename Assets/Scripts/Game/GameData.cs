using Game.Entities;
using Game.Levels;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public Bro Bro => _broData.CreateInstance();

        [SerializeField] private int _startCountPlayerLives;
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private Level _prefab;
        [SerializeField] private BroData _broData; 

        public Level CreateLevelInstance()
        {
            var instance = Instantiate(_prefab);
            instance.Initialzie();
            return instance;
        }

    }
}