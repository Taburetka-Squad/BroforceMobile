using UnityEngine;
using System.Collections;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Entities
{
    public class WanderAI : Enemy
    {
        [SerializeField] private float _movementRange;
        [SerializeField] private float _movementDelay;
        protected override bool CanJump => false;

        private void Start()
        {
            _tree = new BehaviorTreeBuilder(gameObject).Sequence().
                Condition(CanMove).Do(Go).WaitTime(_movementDelay).
                Condition(CanShoot).Do(Fire).
                End().Build();

            Initialize(_data);
        }
        private void Update()
        {
            _tree.Tick();
        }

        private bool CanMove()
        {
            return true;
        }
        private TaskStatus Go()
        {
            Vector2 moveDirection = new Vector2(Random.Range(-1, 2), 0);
            Debug.Log(moveDirection);

            Move(moveDirection);
            Rotate(moveDirection);

            return TaskStatus.Success;
        }
    }
}
