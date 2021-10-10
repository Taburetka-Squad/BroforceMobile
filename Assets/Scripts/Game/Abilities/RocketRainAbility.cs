using System.Collections;
using UnityEngine;

namespace Game.Abilities
{
    [CreateAssetMenu(menuName = "Abilities/RocketRain", order = 0)]
    public class RocketRainAbility : ScriptableAbility
    {
        [SerializeField] private Rocket _prefab;
        [SerializeField] private int _rocketCountPerOneUse;
        [SerializeField] private float _speed;
        [SerializeField] private float _launchDelay;

        public override void Use(Transform startTransform)
        {
            IR.UnityApplication.StartDynamicCoroutine(Launch(startTransform));
        }

        private IEnumerator Launch(Transform startTransform)
        {
            for (var i = 0; i < _rocketCountPerOneUse; i++)
            {
                var position = startTransform.position;

                var rocket = Instantiate(_prefab, position, Quaternion.Euler(0,0,startTransform.right.x * 90));
                rocket.Launch(startTransform.right, _speed);
                
                yield return new WaitForSeconds(_launchDelay);
            }
        }
    }
}