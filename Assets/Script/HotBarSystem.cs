using System;
using UnityEngine;

namespace Script
{
    public class HotBarSystem: MonoBehaviour
    { 
        public GameObject hotBar;
        public GameObject selectiveSlot;
        private GameObject selectedItem;
        public GameObject equippedItem;
        void Start()
        {
            PopulateSlot();
        }

        void Update()
        {
            GetSelectiveSlot();
            SetItemSelect();
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

        Vector3 GetPositionSlot(string slotName)
        {
            foreach (Transform child in hotBar.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    if (child.name == slotName)
                    {   
                        selectedItem = child.GetChild(0).gameObject;
                        Debug.Log(child.localPosition);
                        return child.localPosition;
                    }
                }
            }
            return Vector3.zero;
        }

        void GetSelectiveSlot()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha0 + i))) 
                {
                    selectiveSlot.transform.localPosition = GetPositionSlot($"Slot {i}");
                    break;
                }
                else if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha0 )))
                {
                    selectiveSlot.transform.localPosition = GetPositionSlot("Slot 10");
                }
            }
        }

        void SetItemSelect()
        {
            if (selectedItem == null)
            {
                return;
            }
            else
            {
                string itemName = selectedItem.name;
                GameObject itemPrefab = Resources.Load<GameObject>(itemName);
                if (itemPrefab == null)
                {
                    Debug.LogError($"Không tìm thấy Prefab: {itemName} trong Resources!");
                    return;
                }
                if (equippedItem.transform.childCount > 0)
                {
                    Destroy(equippedItem.transform.GetChild(0).gameObject);
                }
                itemPrefab.transform.SetParent(equippedItem.transform);
            }
        
        }
    }
}