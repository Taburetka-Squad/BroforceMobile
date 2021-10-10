using Game.Levels;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "CompanyData", order = 0)]
    public class CompanyData : ScriptableObject
    {
        public LevelData[] LevelDates => _levelDates;
        
        [SerializeField] private LevelData[] _levelDates;
    }
}