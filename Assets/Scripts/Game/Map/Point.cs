using UnityEngine;

namespace Game.Map
{
    public class Point : MonoBehaviour
    {
        public void MoveObjectToMe(GameObject gameObject)
        {
            gameObject.transform.position = transform.position;
        }
    }
}