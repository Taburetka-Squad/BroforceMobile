using System;
using System.Linq;
using Game.Entities.ArmedEntities.Bro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Entities
{
    [CreateAssetMenu(menuName = "BroFactory", order = 0)]
    public class BroFactory : ScriptableObject
    {
        [SerializeField] private BroData[] _broDatas;

        public Bro GetBro(BroType type)
        {
            var data = _broDatas.FirstOrDefault(s => s.BroType == type);
            return data.CreateInstance();
        }

        public Bro GetRandomBro()
        {
            var index = Random.Range(0, _broDatas.Length);
            var data = _broDatas[index];
            return data.CreateInstance();
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            foreach (var data in _broDatas)
            {
                foreach (var selectedData in _broDatas)
                {
                    if (data == selectedData) continue;

                    if (data.BroType == selectedData.BroType)
                        throw new Exception("Дата такого типа уже есть " + data.BroType);
                }
            }
#endif
        }
    }
}