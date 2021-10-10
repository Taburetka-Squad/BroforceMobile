using System;
using Game.Levels;

namespace Game
{
    [Serializable]
    public class Company
    {
        private LevelData[] _levelDates;
        private int _currentLevelDataIndex;

        public Company(CompanyData companyData)
        {
            _currentLevelDataIndex = 0;
            _levelDates = companyData.LevelDates;
        }

        public LevelData GetCurrentLevelData()
        {
            return _levelDates[_currentLevelDataIndex];
        }

        public LevelData GetLevelData(int index)
        {
            return _levelDates[index];
        }
    }
}