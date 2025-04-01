using System;
using UnityEngine;
using System.Collections.Generic;

namespace Script
{
    public class HotBarSystem : MonoBehaviour
    {
        public GameObject hotBar;
        public GameObject selectiveSlot;
        private GameObject selection;
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
            ConsumedItem(); 
            // Debug.Log(equippedItem.transform.position);
            DropItem();
        }

        // ✅ Tối ưu hóa lưu danh sách Slot ngay từ đầu
        void PopulateSlot()
        {
            foreach (Transform child in hotBar.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    Debug.Log(child.name);
                    _slotDictionary[child.name] = child.gameObject;
                    InventorySystem.Instance.slotList.Add(child.gameObject);
                }
            }
        }

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
                    Debug.Log(2);
                    _selectedItem = null;
                    Debug.Log(3);
                }
                Debug.Log(4);
                selectiveSlot.transform.localPosition = slot.transform.localPosition;
                Debug.Log(5);
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
                    Debug.Log(4);
                    return; // Nếu đã trang bị đúng item, không làm gì cả
                }
            }

            if (_selectedItem == null)
            {
                Debug.Log(3);
                return;
            }

            string itemName = _selectedItem.name.Replace("(Clone)", "").Trim();
            GameObject itemPrefab = Resources.Load<GameObject>(itemName+"_model");
            if (itemPrefab == null)
            {
                Debug.Log($"Không tìm thấy Prefab: {itemName} trong Resources!");
                return;
            }

            GameObject item = Instantiate(itemPrefab, equippedItem.transform.position, Quaternion.Euler(0,0,0));
            item.transform.SetParent(equippedItem.transform, false);
        }
        void ConsumedItem()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (equippedItem.transform.childCount == 0) return;
                GameObject equipment = equippedItem.transform.GetChild(0).gameObject;
                if (equipment == null) return;
                ConsumableItem item = equipment.GetComponent<ConsumableItem>();
                if (item != null )
                {
                    Debug.Log(("Oke"));
                    PlayerState.Instance.ChangeState(item.health,item.food,item.water);
                    Destroy(_selectedItem);
                    Destroy(equipment);

                }
                else
                {
                    Debug.Log("Sản phẩm không thể tiêu thụ");
                }
            }
        }

        void DropItem()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (equippedItem.transform.childCount == 0) return;
                GameObject equipment = equippedItem.transform.GetChild(0).gameObject;
                if (equipment == null) return;
                Debug.Log(equipment.name.Replace("_model(Clone)","").Trim());
                GameObject itemPrefab = Resources.Load<GameObject>(equipment.name.Replace("_model(Clone)","").Trim());
                print(itemPrefab.name);
                GameObject item = Instantiate(itemPrefab, new Vector3(equippedItem.transform.position.x, 0, equippedItem.transform.position.z) , Quaternion.Euler(0,0,0));
                // GameObject item = Instantiate(equipment, equippedItem.transform.position, Quaternion.Euler(0,0,0));
                _selectedItem = null;
                Destroy(equipment);
                InventorySystem.Instance.DeleteItem(equipment.name.Replace("_model(Clone)","").Trim());
            }
        }
    }
}
