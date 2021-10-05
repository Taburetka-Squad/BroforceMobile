using Game.Inputs;
using Game.Inputs.ShootInput;
using Game.Weapons;

namespace Game.Entities.ArmedEntities
{
    public abstract class ArmedEntity : Entity
    {
        protected IShootInput ShootInput = new KeyBoardShootInput();
        protected WeaponSlot WeaponSlot => _weaponSlot;
        private WeaponSlot _weaponSlot;
        
        protected abstract override bool CanJump { get; }

        public void Initialize(ArmedEntityData data)
        {
            base.Initialize(data);
            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
      //      ShootInput.Shot += Shoot;
        }
        
        protected void Shoot()
        {
            WeaponSlot.CurrentWeapon.Shoot();
        }

        protected abstract override void Die();
    }
}