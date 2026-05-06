using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Transform player;

    public float distance = 5f;
    public float height = 2f;
    public float shoulderOffset = 0.5f;

    public float sensitivity = 200f;
    public float minY = -30f;
    public float maxY = 60f;

    float currentX = 0f;
    float currentY = 10f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        currentX += mouseX;
        currentY -= mouseY;
        currentY = Mathf.Clamp(currentY, minY, maxY);
    }

    // void LateUpdate()
    // {
    //     Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
    //     Vector3 direction = new Vector3(0, 0, -distance);

    //     Vector3 position = player.position + Vector3.up * height + rotation * direction;

    //     transform.position = position;
    //     transform.LookAt(player.position + Vector3.up * height);
    // }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // offset lệch vai
        Vector3 offset = new Vector3(shoulderOffset, height, -distance);

        Vector3 position = player.position + rotation * offset;

        transform.position = position;

        // nhìn vào player (hơi lệch lên)
        transform.LookAt(player.position + Vector3.up * height);
    }
}