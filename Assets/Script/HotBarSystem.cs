using UnityEngine;

namespace Script
{
    public class HotBarSystem: MonoBehaviour
    {
        public GameObject hotBar;

        void Start()
        {
            PopulateSlot();
        }
        void PopulateSlot()
        {
            foreach (Transform child in hotBar.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    InventorySystem.Instance.slotList.Add(child.gameObject);
                }
            }
        }
    }
}