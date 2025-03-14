using UnityEngine;

namespace Script
{
    public class PlayerState : MonoBehaviour
    {
        public int _currentHealth;
        public int _maxHealth ;
        public static PlayerState Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            _currentHealth = 100;
            _maxHealth = 100;
        }
    }
}
