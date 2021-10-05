using UnityEngine;

namespace Game.Map
{
    public class SpawnPoint : Point
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.position,0.2f);
        }
    }
}