using System.Threading.Tasks;
using UnityEngine;

namespace Game.Abilities
{
    [CreateAssetMenu(menuName = "Abilities/RocketRain", order = 0)]
    public class RocketRainAbility : ScriptableObject, IAbility
    {
        [SerializeField] private Rocket _prefab;
        [SerializeField] private int _rocketCountPerOneUse;
        [SerializeField] private float _speed;
        [SerializeField] private int _launchDelay;

        public async void Use(Transform startTransform)
        {
            for (var i = 0; i < _rocketCountPerOneUse; i++)
            {
                var position = startTransform.position;

                var rocket = Instantiate(_prefab, position, Quaternion.Euler(0,0,startTransform.right.x * 90));
                rocket.Launch(startTransform.right, _speed);
                
                await Task.Delay(_launchDelay * 100);
            }
        }
    }
}