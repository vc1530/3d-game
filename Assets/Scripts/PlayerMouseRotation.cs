using UnityEngine;

public class PlayerMouseRotation : MonoBehaviour
{
    // Sensitivity of mouse movement
    public float mouseSensitivity = 100f;

    // Minimum and maximum vertical angles the player can rotate
    public float minYAngle = -80f;
    public float maxYAngle = 80f;

    // Rotation around the X axis
    private float rotationX = 0f;

    void Update()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotate the player around the Y axis based on mouse movement
        transform.Rotate(Vector3.up * mouseX);
    }
}