namespace Game.Entities
{
    public class DummyAI : BaseAI
    {
        protected override bool CanJump => false;

        private void FixedUpdate()
        {
            if(React())
                Fire();
        }
        
        protected override bool React()
        {
            var result = Look();
            return result.collider != null && IsPlayer(result);
        }
        
        protected override void Die()
        {
        }

    }
}