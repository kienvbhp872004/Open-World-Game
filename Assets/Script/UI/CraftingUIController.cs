using UnityEngine;

namespace Script
{
    public class CraftingUIController: MonoBehaviour
    {
        // Giả sử bạn có 2 GameObject con để hiển thị danh sách "Tool" và "Armor"
        public GameObject toolOptions;
        public GameObject armorOptions;

        void Start()
        {
            toolOptions.SetActive(false);
            armorOptions.SetActive(false);
        }
        // Hàm hiển thị ToolOptions và ẩn ArmorOptions
        public void ShowToolOptions()
        {
            toolOptions.SetActive(true);
            armorOptions.SetActive(false);
            Debug.Log("Hiển thị danh sách Tool!");
        }

        // Hàm hiển thị ArmorOptions và ẩn ToolOptions
        public void ShowArmorOptions()
        {
            toolOptions.SetActive(false);
            armorOptions.SetActive(true);
            Debug.Log("Hiển thị danh sách Armor!");
        }
    }
}