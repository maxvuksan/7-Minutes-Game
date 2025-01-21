using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public Transform playerBody; // The player's body (objects) to rotate horizontally
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    public float clampAngle = 85f; // Maximum angle for vertical head movement

    private static float rotX = 0f; // Initialize the vertical rotation
    private static float rotY = 0f;

    public static float rotationOffsetX;
    public static float rotationOffsetY;

    static bool disableMovement;



    // used when panning
    public static void SetDisableMovement(bool state){

        disableMovement = state;
        
        if(state){
            Cursor.lockState = CursorLockMode.Confined; // Lock cursor to center of the screen
            Cursor.visible = false; // Hide the cursor
        }
        else{
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false; // Hide the cursor
            
        }
    }
    public static void SetRotation(float rX, float rY){
        rotX = rX;
        rotY = rY;
    }

    public static bool GetDisableMovement(){
        return disableMovement;
    }

    void Start(){
        rotationOffsetX = 0;
        rotationOffsetY = 0;
        SetDisableMovement(false);
    }

    void Update()
    {
        HandleHeadMovement();
    }

    void HandleHeadMovement(){

        float mouseX = 0;
        float mouseY = 0;

        if(!disableMovement){
            
            // Get mouse input for X (horizontal) and Y (vertical)
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Apply the rotation offset to the horizontal and vertical mouse input
            mouseX += rotationOffsetX;
            mouseY += rotationOffsetY;

        }

        rotY += mouseX;

        rotX -= mouseY; // Invert the direction for natural movement
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle); // Clamping the vertical rotation angle

        Quaternion playerBodyRotation = Quaternion.Euler(0f, rotY + rotationOffsetY, 0f); // Only rotate around Y-axis for body
        Quaternion headRotation = Quaternion.Euler(rotX + rotationOffsetX, 0f, 0f); // Only rotate around X-axis for head

        playerBody.localRotation = headRotation;
        transform.localRotation = playerBodyRotation; // Apply the head rotation directly to the camera (transform)
    }
}
