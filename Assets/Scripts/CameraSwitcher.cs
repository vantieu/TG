using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera fpsCamera;
    public Camera tpsCamera;

    bool isFPS = true;

    void Start()
    {
        SetCamera(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            isFPS = !isFPS;
            SetCamera(isFPS);
        }
    }

    void SetCamera(bool fps)
    {
        fpsCamera.enabled = fps;
        tpsCamera.enabled = !fps;

        // bật/tắt audio listener tránh warning
        fpsCamera.GetComponent<AudioListener>().enabled = fps;
        tpsCamera.GetComponent<AudioListener>().enabled = !fps;
    }
}