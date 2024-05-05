using UnityEngine;

public class PlayerMouseRotation : MonoBehaviour
{
    // Sensitivity of mouse movement
    public float mouseSensitivity = 100f;

    public Transform playerBody; // Reference to the player GameObject

    float verticalRotation = 0f;

    void Update()
    {
        // Mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player body left/right based on mouse X movement
        playerBody.Rotate(Vector3.up * mouseX);

        // Calculate vertical rotation and clamp it to avoid flipping
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Apply vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0f);
    }
}