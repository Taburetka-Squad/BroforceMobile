using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Entities
{
    public class DummyAI : Enemy
    {
        protected override bool CanJump => false;

        private void Start()
        {
            _tree = new BehaviorTreeBuilder(gameObject).Sequence().Condition(CanShoot).Do(Fire).End().Build();

            Initialize(_data);
        }
        private void Update()
        {
            _tree.Tick();
        }
    }
}