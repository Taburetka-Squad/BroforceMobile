using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using UnityEngine;

namespace Game.Entities
{
    public class DummyAI : BaseAI
    {
        [SerializeField] private BehaviorTree _tree;
        protected override bool CanJump => false;

        private void Start()
        {
            _tree = new BehaviorTreeBuilder(gameObject).Do("1121212", Fire).End().Build();
            base.Initialize(_data);
        }
        private void Update()
        {
            _tree.Tick();
        }
        private TaskStatus Fire()
        {
            base.Fire();
            return TaskStatus.Success;
        }
        protected override bool CanFire()
        {
            var result = Look();
            return result.collider != null && IsPlayer(result);
        }
        protected override void Die() { }
    }
}