using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public Camera pcCamera;
    public GameObject xrRig;

    private bool isInVR = true;

    void Start()
    {
        UpdateCameraState();
    }

    void Update()
    {
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            ToggleCamera();
        }
    }

    private void ToggleCamera()
    {
        isInVR = !isInVR;
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