namespace Game.Pools
{
    public interface IPoolReturn
    {
        void ReturnToPool(PooledObject obj);
    }
}