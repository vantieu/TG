using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Camera playerCamera;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ===== MOUSE INPUT =====
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * 100f * Time.deltaTime;

        // ===== UP / DOWN (camera) =====
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // ===== LEFT / RIGHT (player) =====
        transform.Rotate(Vector3.up * mouseX);
    }
}