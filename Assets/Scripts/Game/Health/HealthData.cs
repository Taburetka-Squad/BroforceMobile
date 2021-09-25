using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Health
{
    [CreateAssetMenu(menuName = "HealthData", order = 0)]
    public class HealthData : ScriptableObject
    {
        [MinMaxSlider(0, 100), SerializeField] private Vector2Int _hitPoints;

        public Health GetInstance()
        {
            return new Health(Random.Range(_hitPoints.x, _hitPoints.y));
        }
    }
}