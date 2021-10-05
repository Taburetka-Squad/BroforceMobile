using UnityEngine;

namespace Game
{
    public class Game
    {
        public Player Player { get; private set; }

        public Game(GameData data)
        {
            Start(data);
        }

        public void Start(GameData data)
        {
            var level = data.CreateLevelInstance();

            var bro = data.Bro;
            level.PlayerSpawnPoint.MoveObjectToMe(bro.gameObject);
            
            Player = new Player(1, bro);
            Player.BroDied += OnBroDied;
        }

        private void OnBroDied()
        {
            Debug.Log("Game Ended");
        }
    }
}