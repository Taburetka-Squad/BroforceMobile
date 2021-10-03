namespace Game.Map.Blocks
{
    public class Dirt : Block
    {
        public override void OnMapInitialized()
        {
            
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}