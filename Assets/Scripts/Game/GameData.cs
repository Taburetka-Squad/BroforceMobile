using Game.Levels;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public Difficulty Difficulty => _difficulty;
        public LevelData LevelData => _levelData;
        
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private LevelData _levelData;

    }
}