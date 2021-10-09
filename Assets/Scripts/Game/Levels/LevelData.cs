using Game.Entities;
using UnityEngine;

namespace Game.Levels
{
    [CreateAssetMenu(menuName = "LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public BroFactory Factory => _broFactory;
        public int StartCountPlayerLives => _startCountPlayerLives;
        public GameMap[] GameMapPrefabs => _gameMapPrefab;
        
        [SerializeField] private int _startCountPlayerLives;
        [SerializeField] private GameMap[] _gameMapPrefab;
        [SerializeField] private BroFactory _broFactory;

        public GameMap CreateMapInstance(GameMap gameMapPrefab)
        {
            var instance = Instantiate(gameMapPrefab);
            instance.Initialzie();
            return instance;
        }
    }
}