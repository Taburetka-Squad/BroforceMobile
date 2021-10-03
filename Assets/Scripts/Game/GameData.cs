using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "MENUNAME", order = 0)]
    public class GameData : ScriptableObject
    {
        [SerializeField] private int _startCountPlayerLives;
        [SerializeField] private Difficulty _difficulty;
        
    }
}