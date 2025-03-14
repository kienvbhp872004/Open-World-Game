using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class InventorySystem : MonoBehaviour
    {
        public static InventorySystem Instance { get; private set; }
        public bool isOpen;
        public GameObject inventory_UI;
        public GameObject UI;
        public List<GameObject> slotList = new List<GameObject>();
        public List<string> itemList = new List<string>();
        private GameObject _itemAdd;
        private GameObject _whatSlotEquip;
        public bool isFull;
        public Dictionary<string, int> itemCount = new Dictionary<string, int>();

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
            itemCount["Stone"] = 0;
            itemCount["Stick"] = 0;
            itemCount["Meat"] = 0;
            isOpen = false;
            PopulateSlotList();
            isFull = false;
        }

        private void PopulateSlotList()
        {
            foreach (Transform child in inventory_UI.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    slotList.Add(child.gameObject);
                }
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) && !isOpen)
            {
                isOpen = true;
                UI.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.I) && isOpen)
            {
                isOpen = false;
                UI.SetActive(false);
            }
        }

        public void DeleteItem(string itemName, int quantity = 1)
        {
            int itemsRemoved = 0;
            List<GameObject> itemsToDelete = new List<GameObject>();

            // Tìm tất cả các slots chứa item cần xóa
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount > 0)
                {
                    string childName = slot.transform.GetChild(0).name.Replace("(Clone)", "").Trim();
                    if (childName == itemName && itemsRemoved < quantity)
                    {
                        itemsToDelete.Add(slot.transform.GetChild(0).gameObject);
                        itemsRemoved++;
                    }
                }
            }

            // Xóa các item đã tìm thấy
            foreach (GameObject item in itemsToDelete)
            {
                itemList.Remove(itemName);
                Destroy(item);
            }

            // Cảnh báo nếu không xóa đủ số lượng
            if (itemsRemoved < quantity)
            {
                Debug.LogWarning($"Không tìm thấy đủ item '{itemName}' để xóa.  Đã xóa: {itemsRemoved}, Yêu cầu: {quantity}");
            }
        }


        public void AddItem(string itemName)
        {
            if (IsFull())
            {
                Debug.Log("Inventory is full");
            }
            else
            {
                _whatSlotEquip = FindNextEmptySlot();
                _itemAdd = (GameObject)Instantiate(Resources.Load<GameObject>(itemName),
                    _whatSlotEquip.transform.position, _whatSlotEquip.transform.rotation);
                _itemAdd.transform.SetParent(_whatSlotEquip.transform);
                itemList.Add(itemName);
            }
        }

        private bool IsFull()
        {
            int count = 0;
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount > 0)
                {
                    count++;
                }
            }

            if (count == slotList.Count)
            {
                isFull = true;
                return true;
            }

            return false;
        }

        public void GetNameAllItem()
        {
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount > 0)
                {
                    Debug.Log(slot.transform.GetChild(0).name);
                }
            }
        }
        private GameObject FindNextEmptySlot()
        {
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount == 0)
                {
                    return slot;
                }
            }

            return new GameObject();
        }

        private GameObject FindSlot(string itemName)
        {
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount > 0)
                {
                    string childName = slot.transform.GetChild(0).name.Replace("(Clone)", "").Trim();
                    if (childName == itemName)
                    {
                        return slot;
                    }
                }
            }
            Debug.Log(1);
            return null; // Trả về null nếu không tìm thấy
        }

    }
}