using System;
using System.Linq;
using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "EnemyFactory", order = 0)]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private EnemyData[] _enemyDates;

        public Enemy GetEnemy(EnemyType type)
        {
            var data = _enemyDates.First(s => s.EnemyType == type);
            return data.CreateInstance();
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            foreach (var data in _enemyDates)
            {
                foreach (var selectedData in _enemyDates)
                {
                    if (data == selectedData) continue;

                    if (data.EnemyType == selectedData.EnemyType)
                        throw new Exception("Дата такого типа уже есть " + data.EnemyType);
                }
            }
        }
#endif
    }
}