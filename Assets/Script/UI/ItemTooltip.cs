using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script
{
    public class ItemTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public static ItemTooltip Instance { get; private set; }
        public GameObject tooltipPanel;
        public Text itemName;
        public Image itemImage;
        public Text itemDescription;
        private bool isHovered;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isHovered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isHovered = false;
            Invoke(nameof(HideTooltip), 0.1f);
        }

        public bool IsPointerOverTooltip()
        {
            return isHovered;
        }

        private void HideTooltip()
        {
            if (!isHovered)
            {
                tooltipPanel.SetActive(false);
            }
        }
    }
}