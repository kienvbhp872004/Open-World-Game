using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class CraftingSystem: MonoBehaviour
    {
        private bool _isOpen;
        public Button[] listOfButtons;
        public GameObject craftingTable;
        public static CraftingSystem Instance { get; private set;}

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                Instance = this;
            }
        }
        void Start()
        {
            _isOpen = false;
            craftingTable.SetActive(false);
        }
        void Update()
        {
            if (_isOpen&& Input.GetKeyDown(KeyCode.I))
            {
                craftingTable.SetActive(false);
                _isOpen = false;
            }
            else if (!_isOpen && Input.GetKeyDown(KeyCode.I))
            {
                craftingTable.SetActive(true);
                _isOpen = true;
            }
        }
    }
}
