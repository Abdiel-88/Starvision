using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float panSpeed = 20f; // Speed of the camera pan
    public float rotationSpeed = 0.1f; // Speed of the camera rotation when panning
    private Vector3 initialPosition; // Initial position of the camera
    private Quaternion initialRotation; // Initial rotation of the camera
    private Transform currentTarget; // Current target to follow
    private Vector3 offset = new Vector3(0, 3, -5); // Offset from the target

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float h = rotationSpeed * Input.GetAxis("Mouse X");
            float v = rotationSpeed * Input.GetAxis("Mouse Y");

            transform.Translate(h, v, 0);
        }

        if (currentTarget != null)
        {
            // Directly set the camera's position and rotation to follow the target
            transform.position = currentTarget.position + offset;
            transform.LookAt(currentTarget);
        }
    }

    public void SetTarget(Transform target)
    {
        currentTarget = target;
    }

    public void ResetCamera()
    {
        currentTarget = null;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
