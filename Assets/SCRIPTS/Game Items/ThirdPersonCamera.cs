using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public float distance = 5f; 
    public float height = 2f; 
    public float rotationSpeed = 5f; 

    private float currentAngle = 0f; 
    private float currentHeight = 0f; 
    private float targetAngle = 0f; 
    private float targetHeight = 0f; 

    private bool isMouseLocked = false; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            isMouseLocked = !isMouseLocked;
            if (isMouseLocked)
            {
                Cursor.lockState = CursorLockMode.Locked; 
                Cursor.visible = false; 
            }
            else
            {
                Cursor.lockState = CursorLockMode.None; 
                Cursor.visible = true; 
            }
        }

        if (isMouseLocked)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y"); 

            targetAngle += horizontalInput * rotationSpeed;
            targetHeight -= verticalInput * rotationSpeed;

            targetHeight = Mathf.Clamp(targetHeight, -45f, 45f);

            currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);
            currentHeight = Mathf.Lerp(currentHeight, targetHeight, Time.deltaTime * rotationSpeed);

            Vector3 direction = new Vector3(0, 0, -distance); 
            Quaternion rotation = Quaternion.Euler(currentHeight, currentAngle, 0);
            transform.position = player.position + rotation * direction;

            // Make the camera look at the player
            transform.LookAt(player);
        }
    }
}
