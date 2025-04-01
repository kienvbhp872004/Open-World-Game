using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Script
{
    public class PlayerState : MonoBehaviour
    {
        public int _currentHealth;
        public int _maxHealth ;
        public int _currentFood;
        public int _maxFood;
        public int _currentWater;
        public int _maxWater;
        public GameObject StatusBar;
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
            _currentFood = 100;
            _maxFood = 100;
            _currentWater = 100;
            _maxWater = 100;
        }

        void Update()
        {
            SetActive();
        }
        void SetActive()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (InventorySystem.Instance.isOpen)
                {
                    StatusBar.SetActive(false);
                }
                else
                {
                    StatusBar.SetActive(true);
                }
            }   
         
        }

        public void ChangeState(int Health, int Food, int Water)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + Health, 0, _maxHealth);
            _currentFood = Mathf.Clamp(_currentFood + Food, 0, _maxFood);
            _currentWater = Mathf.Clamp(_currentWater + Water, 0, _maxWater);
        }
    }
}
