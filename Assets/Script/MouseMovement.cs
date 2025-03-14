using Script;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        LockCursor();
        Debug.Log("Cursor locked");
    }

    void Update()
    {
        if (InventorySystem.Instance.isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
        else if(!InventorySystem.Instance.isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
                    
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            yRotation += mouseX;
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ToggleCursor()
    {
        bool isLocked = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = isLocked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isLocked;
    }
}