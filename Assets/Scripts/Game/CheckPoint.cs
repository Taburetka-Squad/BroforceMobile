using System;

using Game.Entities;

using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CheckPoint : MonoBehaviour
    {
        public event Action<CheckPoint> Reached;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                Reached?.Invoke(this);
            }
        }
    }
}