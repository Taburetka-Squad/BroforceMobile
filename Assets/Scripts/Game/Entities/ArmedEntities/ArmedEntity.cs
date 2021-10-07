using System;
using Game.Inputs;
using Game.Inputs.ShootInput;

namespace Game.Entities.ArmedEntities
{
    public abstract class ArmedEntity : Entity
    {
        protected IAttackInput AttackInput = new KeyBoardAttackInput();
        private IAttack _attack;

        protected abstract override bool CanJump { get; }

        public void Initialize(ArmedEntityData data)
        {
            base.Initialize(data);
            _attack = data.Attack;

            //      AttackInput.Shot += Attack;
        }

        protected void Attack()
        {
            if (_attack == null) throw new Exception("Attack is null");
            _attack.Attack();
        }

        protected abstract override void Die();
    }
}