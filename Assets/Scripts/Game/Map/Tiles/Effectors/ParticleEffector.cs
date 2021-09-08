using UnityEngine;

namespace Game.Map.Tiles.Effectors
{
    [CreateAssetMenu(menuName = "Game/Tiles/Effectors/Particle")]
    class ParticleEffector : TileEffector
    {
        [SerializeField] private ParticleSystem _prefab;

        public override void SpawnIn(Vector2 position)
        {
            var particleSystem = Instantiate(_prefab, position, Quaternion.identity);

            Destroy(particleSystem.gameObject, particleSystem.main.startLifetime.constant + 1);
        }
    }
}