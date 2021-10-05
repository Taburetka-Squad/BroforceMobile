using System;
using Cinemachine;
using UnityEngine;

namespace Game
{
    public class GameTest : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private CinemachineVirtualCamera _cinemachine;
        [SerializeField]
        private Game _game;

        private void Awake()
        {
            _game = new Game(_gameData);
            _cinemachine.Follow = _game.Player.CurrentBro.transform;
        }


        private void Update()
        {
            
        }
    }
}