using UnityEngine;

public class PlaceableItem : MonoBehaviour
{
    public GameObject itemPrefab; // Vật phẩm sẽ được đặt.
    public GameObject ghostPrefab; // Ghost item (bản sao mờ của vật phẩm)
    public float placementDistance = 5f; // Khoảng cách để người chơi có thể đặt vật phẩm.
    public LayerMask placementLayerMask; // Các layer mà vật phẩm có thể được đặt lên.
    public Color ghostColor = new Color(1f, 1f, 1f, 0.5f); // Màu của ghost item (mờ).
    public Color invalidPlacementColor = new Color(1f, 0f, 0f, 0.5f); // Màu cảnh báo khi không thể đặt vật phẩm.

    private Camera playerCamera;
    private GameObject ghostItem; // Ghost item sẽ được hiển thị trước khi đặt vật phẩm.
    private Renderer[] childRenderers; // Renderer của ghost item để thay đổi màu sắc.

    void Start()
    {
        playerCamera = Camera.main; // Lấy camera chính của người chơi.

        // Tạo ghost item (sử dụng prefab ghost) và ẩn nó ngay từ đầu
        ghostItem = Instantiate(ghostPrefab);
        ghostItem.SetActive(false);

        // Lấy tất cả các renderer của các đối tượng con của ghost item
        childRenderers = ghostItem.GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        HandleItemPlacement();
    }

    void HandleItemPlacement()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Kiểm tra nếu raycast trúng đối tượng hợp lệ
        if (Physics.Raycast(ray, out hit, placementDistance, placementLayerMask))
        {
            // Cập nhật vị trí và góc cho ghost item
            Vector3 placePosition = hit.point;
            ghostItem.transform.position = placePosition;
            ghostItem.transform.rotation = Quaternion.identity;

            // Kiểm tra vị trí có hợp lệ không và thay đổi màu của ghost item
            if (IsPositionValid(placePosition))
            {
                // Nếu không bị chặn, giữ màu mặc định (mờ)
                SetGhostItemColor(ghostColor);
            }
            else
            {
                // Nếu có vật thể chặn, chuyển sang màu cảnh báo (đỏ)
                SetGhostItemColor(invalidPlacementColor);
            }

            // Kiểm tra nếu nhấn chuột trái để đặt vật phẩm
            if (Input.GetMouseButtonDown(0) && IsPositionValid(placePosition))
            {
                PlaceItem(placePosition, hit.normal);
            }

            // Hiển thị ghost item khi raycast trúng mặt phẳng hợp lệ
            ghostItem.SetActive(true);
        }
        else
        {
            // Ẩn ghost item khi không có mặt phẳng hợp lệ
            ghostItem.SetActive(false);
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        // Kiểm tra có vật thể nào khác tại vị trí này không
        Collider[] colliders = Physics.OverlapSphere(position, 0.5f); // Kiểm tra trong bán kính nhỏ
        return colliders.Length == 0; // Nếu không có collider nào khác, vị trí hợp lệ
    }

    void PlaceItem(Vector3 position, Vector3 normal)
    {
        // Tạo vật phẩm thật tại vị trí và góc đúng
        GameObject placedItem = Instantiate(itemPrefab, position, Quaternion.LookRotation(normal));
        placedItem.SetActive(true);

        // Ẩn ghost item khi vật phẩm được đặt
        ghostItem.SetActive(false);
    }

    // Phương thức thay đổi màu sắc cho tất cả các renderer của ghost item
    void SetGhostItemColor(Color color)
    {
        foreach (var renderer in childRenderers)
        {
            renderer.material.color = color;
        }
    }
}
