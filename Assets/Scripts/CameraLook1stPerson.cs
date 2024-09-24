using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook1stPerson : MonoBehaviour
{
    public Transform playerRef;  // Reference to the player object or helicopter's body
    public float mouseSensitivity = 0.05f;
    private float xRotation = 0f;

    private void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Ensure the mouse is available before trying to read input
        if (Mouse.current != null)
        {
            Vector2 mouseInput = Mouse.current.delta.ReadValue(); // Get mouse movement
            float mouseX = mouseInput.x * mouseSensitivity * 0.25f; 
            float mouseY = mouseInput.y * mouseSensitivity * 0.25f;


            // Adjust vertical (pitch) rotation
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limit vertical look to avoid flipping over

            // Apply vertical rotation to the camera
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Rotate the player (horizontal rotation)
            playerRef.Rotate(Vector3.up * mouseX);
        }
    }
}

