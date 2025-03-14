using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class ToolUIController : MonoBehaviour
    {
        private Dictionary<string,int> itemCount = new Dictionary<string, int>();

        public void CraftItem(string itemName)
        {
            itemCount = InventorySystem.Instance.itemCount;
            if (itemName == "Axe")
            {
                if (itemCount["Stone"] >= 3 && itemCount["Stick"] >= 2)
                {
                    InventorySystem.Instance.DeleteItem("Stone",3);
                    InventorySystem.Instance.DeleteItem("Stick",2);
                    InventorySystem.Instance.itemCount["Stone"] -= 3;
                    InventorySystem.Instance.itemCount["Stick"] -= 2;
                    InventorySystem.Instance.AddItem("Axe");
                } 
                Debug.Log("Crafted");
            }
            if (itemName == "Bow")
            {
                if (itemCount["Stone"] >= 3 && itemCount["Stick"] >= 2)
                {
                    InventorySystem.Instance.DeleteItem("Stone",3);
                    InventorySystem.Instance.DeleteItem("Stick",2);
                    InventorySystem.Instance.itemCount["Stone"] -= 3;
                    InventorySystem.Instance.itemCount["Stick"] -= 2;
                    InventorySystem.Instance.AddItem("Bow");
                } 
                Debug.Log("Crafted");
            }
            if (itemName == "Shovel")
            {
                if (itemCount["Stone"] >= 3 && itemCount["Stick"] >= 2)
                {
                    InventorySystem.Instance.DeleteItem("Stone",3);
                    InventorySystem.Instance.DeleteItem("Stick",2);
                    InventorySystem.Instance.itemCount["Stone"] -= 3;
                    InventorySystem.Instance.itemCount["Stick"] -= 2;
                    InventorySystem.Instance.AddItem("Shovel");
                } 
                Debug.Log("Crafted");
            }
            if (itemName == "Hammer")
            {
                if (itemCount["Stone"] >= 3 && itemCount["Stick"] >= 2)
                {
                    InventorySystem.Instance.DeleteItem("Stone",3);
                    InventorySystem.Instance.DeleteItem("Stick",2);
                    InventorySystem.Instance.itemCount["Stone"] -= 3;
                    InventorySystem.Instance.itemCount["Stick"] -= 2;
                    InventorySystem.Instance.AddItem("Axe");
                } 
                Debug.Log("Crafted");
            }
            else
            {
                Debug.Log("Can not craft "+" "+itemName);
            }
        }

        public void BackButton()
        {
            gameObject.SetActive(false);
            CraftingSystem.Instance.craftingTable.SetActive(true);
        }
    }
}