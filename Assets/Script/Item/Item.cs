using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script
{
    public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string itemName;
        public string itemDescription;
        

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (ItemTooltip.Instance == null) return;

            GameObject itemPrefab = Resources.Load<GameObject>(itemName);
            if (itemPrefab == null)
            {
                Debug.LogError($"Không tìm thấy Prefab: {itemName} trong Resources!");
                return;
            }

            ItemTooltip.Instance.itemImage.sprite = itemPrefab.GetComponent<Image>().sprite;
            ItemTooltip.Instance.itemName.text = itemName;
            ItemTooltip.Instance.itemDescription.text = itemDescription;

            ItemTooltip.Instance.tooltipPanel.transform.position = transform.position + new Vector3(200, 150, 0);
            ItemTooltip.Instance.tooltipPanel.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Invoke(nameof(HideTooltip), 0.1f); // Delay để kiểm tra con trỏ có vào tooltip không
        }

        void Update()
        {
            
        }
        private void HideTooltip()
        {
            if (!ItemTooltip.Instance.IsPointerOverTooltip())
            {
                ItemTooltip.Instance.tooltipPanel.SetActive(false);
            }
        }
    }
}