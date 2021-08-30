using UnityEngine;

namespace Game.Weapons.Bullets
{
    class Bullet : MonoBehaviour
    {
        private BulletData _data;

        public void Initialize(BulletData data)
        {
            _data = data;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // TODO
        }
    }
}