using System;
using UnityEngine;

namespace Script
{
    public class InteractableObject : MonoBehaviour
    {
        public String nameObject;
        public bool playerInRange;
        public String GetNameObject()
        {
            return nameObject;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Oke");
                playerInRange = true;
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && playerInRange)
            {
                if (SelectionManager.instance == null)
                {
                    Debug.LogError("SelectionManager.instance is NULL!");
                    return;
                }

                if (InventorySystem.Instance == null)
                {
                    Debug.LogError("InventorySystem.Instance is NULL!");
                    return;
                }

                if (NotificationUI.Instance == null)
                {
                    Debug.LogError("NotificationUI.Instance is NULL!");
                    return;
                }

                if (SelectionManager.instance.onTarget && SelectionManager.instance.selectedObject == gameObject)
                {
                    if (!InventorySystem.Instance.isFull)
                    {
                        InventorySystem.Instance.itemCount[nameObject]++;
                        InventorySystem.Instance.AddItem(nameObject);
                        NotificationUI.Instance.ShowNotification(nameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }

    }
}
