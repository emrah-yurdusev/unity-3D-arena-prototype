using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float mouseSensitivity = 150f;
    public float distance = 6f;
    public float height = 3f;
    public float smoothSpeed = 10f;

    private float yaw;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);

        Vector3 offset = rotation * new Vector3(0f, height, -distance);
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}