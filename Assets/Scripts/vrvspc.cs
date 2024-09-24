using UnityEngine;
using UnityEngine.InputSystem; // Make sure to include this

public class CameraManager : MonoBehaviour
{
    public Camera pcCamera; // Assign the PC Camera in the Inspector
    public GameObject xrRig; // Assign the XR Rig in the Inspector

    private bool isInVR = true; // Start in VR mode

    void Start()
    {
        UpdateCameraState();
    }

    void Update()
    {
        // Check for 'V' key press to toggle
        if (Keyboard.current.vKey.wasPressedThisFrame) // Change to 'V' key
        {
            ToggleCamera();
        }
    }

    private void ToggleCamera()
    {
        isInVR = !isInVR; // Toggle the state
        UpdateCameraState();
    }

    private void UpdateCameraState()
    {
        if (isInVR)
        {
            pcCamera.gameObject.SetActive(false);
            xrRig.SetActive(true);
        }
        else
        {
            pcCamera.gameObject.SetActive(true);
            xrRig.SetActive(false);
        }
    }
}