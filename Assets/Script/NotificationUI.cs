using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class NotificationUI : MonoBehaviour
    {
        public static NotificationUI Instance { get; private set; }
        public GameObject notificationUI;
        public GameObject notification;
        TextMeshProUGUI nameObject; 
        public GameObject imageObject;
        [SerializeField] private float _time = 2f; // Gán giá trị mặc định

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            // Kiểm tra notification có được gán hay không
            if (notification == null)
            {
                Debug.LogError("Notification GameObject chưa được gán trong Inspector!");
                return;
            }

            // Tìm TextMeshPro bên trong notification
            nameObject = notification.GetComponent<TextMeshProUGUI>();

            if (nameObject == null)
            {
                Debug.LogError("Không tìm thấy TextMeshPro trong notification!");
            }

            notificationUI.SetActive(false);
        }

        public void ShowNotification(string name)
        {
            if (imageObject.transform.childCount > 0)
            {
                Destroy(imageObject.transform.GetChild(0).gameObject);
            }
            notificationUI.SetActive(true);
            nameObject.text = name;

            // Tạo object từ Resources
            GameObject itemPrefab = Resources.Load<GameObject>(name);
            if (itemPrefab == null)
            {
                Debug.LogError($"Không tìm thấy Prefab: {name} trong Resources!");
                return;
            }

            GameObject item = Instantiate(itemPrefab, imageObject.transform.position, imageObject.transform.rotation);
            item.transform.SetParent(imageObject.transform);

            Invoke(nameof(HideNotification), _time);
        }

        private void HideNotification()
        {
            notificationUI.SetActive(false);
        }
    }
}
