using UnityEngine;

namespace Game.Map
{
    public class Point : MonoBehaviour
    {
        public void MoveObjectToMe(Transform targetTransform)
        {
            targetTransform.transform.position = transform.position;
        }
    }
}