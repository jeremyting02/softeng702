using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook1stPerson : MonoBehaviour
{
    public Transform playerRef;  
    public float mouseSensitivity = 0.05f;
    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            Vector2 mouseInput = Mouse.current.delta.ReadValue();
            float mouseX = mouseInput.x * mouseSensitivity * 0.25f; 
            float mouseY = mouseInput.y * mouseSensitivity * 0.25f;


            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limit vertical look to avoid flipping over

            // Apply vertical rotation to the camera
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Rotate the player (horizontal rotation)
            playerRef.Rotate(Vector3.up * mouseX);
        }
    }
}

