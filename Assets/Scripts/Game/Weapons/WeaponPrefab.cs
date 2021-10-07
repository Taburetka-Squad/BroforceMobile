using UnityEngine;

namespace Game.Weapons
{
    public class WeaponPrefab : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        
        public Transform FirePoint => _firePoint;
    }
}