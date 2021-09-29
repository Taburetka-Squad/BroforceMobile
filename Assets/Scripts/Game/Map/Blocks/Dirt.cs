using System;
using Game.Damage;

namespace Game.Map.Blocks
{
    public class Dirt : Block, IDie
    {
        public event Action Died;
        
        public override void OnMapInitialized()
        {
           
        }

        public void TakeDamage(int damage)
        {
            
        }
    }
}