using System.Linq;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName ="GameDataFactory",order = 0)]
    public class GameDataFactory : ScriptableObject
    {
        [SerializeField] private GameData[] _broDatas;

        public GameData GetGameData(Difficulty difficulty)
        {
            return _broDatas.FirstOrDefault(s => s.Difficulty == difficulty);
        }
    }
}