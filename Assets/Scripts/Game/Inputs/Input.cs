using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Inputs
{
    public class Input
    {
        private List<IInput> _inputs;

        public Input()
        {
            _inputs = new List<IInput>(5);
            IR.UnityApplication.StartDynamicCoroutine(ReadInput());
        }

        public void AddInputToUpdateQueue(IInput input)
        {
            _inputs.Add(input);
        }

        private IEnumerator ReadInput()
        {
            foreach (var input in _inputs)
            {
                input.ReadInput();
            }

            yield return Time.deltaTime;
        }
    }
}