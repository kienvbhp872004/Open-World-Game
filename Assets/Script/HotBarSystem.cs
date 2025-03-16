using System;
using UnityEngine;

namespace Script
{
    public class HotBarSystem: MonoBehaviour
    {
        public GameObject hotBar;
        public GameObject selectiveSlot;
        void Start()
        {
            PopulateSlot();
        }

        void Update()
        {
            GetSelectiveSlot();
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
    }
}