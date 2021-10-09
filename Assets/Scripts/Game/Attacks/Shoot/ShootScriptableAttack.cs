using Game.Projectiles.Bullets;
using UnityEngine;

namespace Game.Weapons
{
    [CreateAssetMenu(menuName = "Game/Weapons/ShootScriptableAttack")]
    public class ShootScriptableAttack : ScriptableAttack
    {
        public BulletData BulletData => _bulletData;
        public float FireRate => _fireRate;

        [Header("References")] [SerializeField]
        private WeaponPrefab _prefab;

        [SerializeField] private BulletData _bulletData;

        [Header("Parameters")] [SerializeField]
        private float _fireRate;

        public override IAttack GetInstance(Transform parent)
        {
            var weapon = Instantiate(_prefab, parent);
            
            var localScale = parent.localScale / 2;
            weapon.transform.localPosition = new Vector3(localScale.x, 0, 0);
            
            return new ShootAttack(this, weapon.FirePoint);
        }
    }
}