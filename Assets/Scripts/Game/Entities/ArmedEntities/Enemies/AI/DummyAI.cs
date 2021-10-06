namespace Game.Entities
{
    public class DummyAI : BaseAI
    {
        protected override bool CanJump => false;

        private void FixedUpdate()
        {
            if(CanFire())
                Fire();
        }
        
        protected override bool CanFire()
        {
            var result = Look();
            return result.collider != null && IsPlayer(result);
        }
        protected override void Die() { }
    }
}