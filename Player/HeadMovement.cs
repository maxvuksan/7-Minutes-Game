using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public Transform playerBody; // The player's body (objects) to rotate horizontally
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    public float clampAngle = 85f; // Maximum angle for vertical head movement

    private float rotX = 0f; // Initialize the vertical rotation

    void Start(){
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    void Update()
    {
        HandleHeadMovement();
    }

    void HandleHeadMovement(){
        // Get mouse input for X (horizontal) and Y (vertical)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body horizontally (left/right)
        transform.Rotate(Vector3.up * mouseX);

        // Update the vertical rotation (up/down), clamping the angle
        rotX -= mouseY; // Invert the direction for natural movement
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle); // Clamping the vertical rotation angle

        // Apply the vertical rotation to the camera (head)
        playerBody.localRotation = Quaternion.Euler(rotX, 0f, 0f); // Only rotate around X-axis for head movement
    }
}
