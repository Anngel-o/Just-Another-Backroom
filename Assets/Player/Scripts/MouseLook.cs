using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [Header("References")]
    public Transform cameraHolder;
    private PlayerInput playerInput;

    [Header("Settings")]
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 80f;

    private Vector2 lookInput;
    private float xRotation = 0f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        mouseSensitivity = Mathf.Clamp(mouseSensitivity, 0.1f, 10f);

        lookInput = playerInput.actions["Look"].ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        // Rotación vertical (cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal (player)
        transform.Rotate(Vector3.up * mouseX);
    }
}
