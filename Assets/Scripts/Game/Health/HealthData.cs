using UnityEngine;

namespace Game.Health
{
    [CreateAssetMenu(menuName = "HealthData", order = 0)]
    public class HealthData : ScriptableObject
    {
        [SerializeField] private int _hitPoints;
        
        public Health GetInstance()
        {
            return new Health(_hitPoints);
        }
    }
}