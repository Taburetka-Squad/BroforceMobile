﻿using System.Collections;
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
                if (startTransform == null)
                    yield break;
                
                var position = startTransform.position;
                var right = startTransform.right;
                
                var rocket = Instantiate(_prefab, position, Quaternion.Euler(0,0,right.x * 90));
                rocket.Launch(right, _speed);
                
                yield return new WaitForSeconds(_launchDelay);
            }
        }
    }
}