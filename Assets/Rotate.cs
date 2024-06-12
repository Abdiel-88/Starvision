using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Speed of the rotation
    private float initialRotationSpeed; // Store initial rotation speed

    void Start()
    {
        initialRotationSpeed = rotationSpeed; // Store the initial rotation speed
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void SetRotationSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }

    public float GetInitialRotationSpeed()
    {
        return initialRotationSpeed;
    }
}
