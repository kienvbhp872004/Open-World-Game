using System;
using UnityEngine;
using System.Collections.Generic;

namespace Script
{
    public class HotBarSystem : MonoBehaviour
    {
        public GameObject hotBar;
        public GameObject selectiveSlot;
        private GameObject _selectedItem;
        public GameObject equippedItem;

        private Dictionary<string, GameObject> _slotDictionary = new Dictionary<string, GameObject>();

        void Start()
        {
            PopulateSlot();
        }

        void Update()
        {
            if (CheckSlotInput()) 
            {
                SetItemSelect();
            }
        }

        // ✅ Tối ưu hóa lưu danh sách Slot ngay từ đầu
        void PopulateSlot()
        {
            foreach (Transform child in hotBar.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    _slotDictionary[child.name] = child.gameObject;
                    InventorySystem.Instance.slotList.Add(child.gameObject);
                }
            }
        }

        // ✅ Tối ưu hóa lấy vị trí của Slot mà không cần lặp lại danh sách
        bool GetPositionSlot(string slotName)
        {
            if (_slotDictionary.TryGetValue(slotName, out GameObject slot))
            {
                if (slot.transform.childCount > 0)
                {
                    _selectedItem = slot.transform.GetChild(0).gameObject;
                }
                else
                {
                    _selectedItem = null;
                }

                selectiveSlot.transform.localPosition = slot.transform.localPosition;
                return true;
            }
            return false;
        }

        // ✅ Tối ưu cách bắt phím chọn Slot
        bool CheckSlotInput()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha0 + i))) 
                {
                    return GetPositionSlot($"Slot {i}");
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha0)) 
            {
                return GetPositionSlot("Slot 10");
            }

            return false;
        }

        // ✅ Tránh tạo lại item liên tục nếu item đã được trang bị rồi
        void SetItemSelect()
        {
            if (equippedItem.transform.childCount > 0)
            {
                Transform currentItem = equippedItem.transform.GetChild(0);
                if (_selectedItem == null || currentItem.name.Replace("(Clone)", "").Trim() != _selectedItem.name)
                {
                    Destroy(currentItem.gameObject);
                }
                else
                {
                    return; // Nếu đã trang bị đúng item, không làm gì cả
                }
            }

            if (_selectedItem == null)
            {
                return;
            }

            string itemName = _selectedItem.name.Replace("(Clone)", "").Trim();
            GameObject itemPrefab = Resources.Load<GameObject>(itemName+"_model");
            if (itemPrefab == null)
            {
                Debug.LogError($"Không tìm thấy Prefab: {itemName} trong Resources!");
                return;
            }

            GameObject item = Instantiate(itemPrefab, equippedItem.transform.position, Quaternion.Euler(0,0,0));
            item.transform.SetParent(equippedItem.transform, false);
        }
    }
}
