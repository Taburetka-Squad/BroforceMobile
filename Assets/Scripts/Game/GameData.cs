using Game.Entities;
using Game.Levels;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public Difficulty Difficulty => _difficulty;
        public int StartCountPlayerLives => _startCountPlayerLives;
        public BroFactory Factory => _broFactory;

        [SerializeField] private int _startCountPlayerLives;
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private Level _prefab;
        [SerializeField] private BroFactory _broFactory;
        
        public Level CreateLevelInstance()
        {
            var instance = Instantiate(_prefab);
            instance.Initialzie();
            return instance;
        }

        public Level CreateLevelInstanceAt(Vector3 position)
        {
            var level = CreateLevelInstance();
            level.transform.position = position;
            return level;
        }
    }
}