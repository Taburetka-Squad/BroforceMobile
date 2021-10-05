namespace Game.Entities
{
    public class DummyAI : BaseAI
    {
        protected override bool CanJump => false;

        private void Update()
        {
            React();
        }
        
        protected override void React()
        {
            var result = Look();
            var canFire = result.collider != null && IsPlayer(result);

            if (canFire)
                StartCoroutine(Fire());
        }
        
        protected override void Die()
        {
        }

    }
}