using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Sensitivity for mouse movement
    public float sensitivity = 100f;

    // Rotation around the X-axis (looking up and down)
    float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the camera horizontally based on mouse movement
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically based on mouse movement
        xRotation -= mouseY;
        // Clamp vertical rotation to prevent flipping upside down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // Apply rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y, 0f);
    }
}