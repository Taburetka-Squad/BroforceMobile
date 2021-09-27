using System;

namespace Game.Damage
{
    public interface IDie : IDamageable
    {
        event Action Died;
    }
}