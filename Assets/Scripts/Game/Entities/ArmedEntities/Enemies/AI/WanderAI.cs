using UnityEngine;
using System.Collections;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Entities
{
    public class WanderAI : Enemy
    {
        [SerializeField] private float _movementDelay;

        private float _lastMoveTime;
        protected override bool CanJump => false;

        private void Start()
        {
            _tree = new BehaviorTreeBuilder(gameObject).Parallel().
                Sequence().
                    Condition(CanShoot).Do(Fire).
                End().
                Sequence().
                    Condition(CanMove).Do(Go).
                End().
                Build();

            Initialize(_data);
        }
        private void Update()
        {
            _tree.Tick();
        }

        private bool CanMove()
        {
            if (Time.time > _lastMoveTime + _movementDelay)
            {
                _lastMoveTime = Time.time;
                return true;
            }

            return false;
        }
        private TaskStatus Go()
        {
            Vector2 moveDirection = new Vector2(Random.Range(-1, 2), 0);

            Move(moveDirection);
            Rotate(moveDirection);

            return TaskStatus.Success;
        }
    }
}
