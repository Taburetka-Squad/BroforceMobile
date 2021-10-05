using System;
using Game.Entities;
using Game.Map;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CheckPoint : Point
    {
        public event Action<CheckPoint> Reached;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Bro>(out _))
            {
                Reached?.Invoke(this);
            }
        }
    }
}