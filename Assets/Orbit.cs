using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform centerObject; // The object to orbit around (e.g., the Sun)
    public float orbitSpeed = 10.0f; // Speed of the orbit

    private Vector3 initialPosition; // Initial position relative to the center object
    private float orbitRadius; // Radius of the orbit
    private float currentAngle = 0.0f;
    private float initialOrbitSpeed; // Store initial orbit speed

    void Start()
    {
        if (centerObject != null)
        {
            initialPosition = transform.position - centerObject.position;
            orbitRadius = initialPosition.magnitude; // Calculate the orbit radius from the initial position
            currentAngle = Mathf.Atan2(initialPosition.z, initialPosition.x); // Calculate the initial angle
            initialOrbitSpeed = orbitSpeed; // Store the initial orbit speed
        }
    }

    void Update()
    {
        if (centerObject != null)
        {
            currentAngle += orbitSpeed * Time.deltaTime; // Update the angle
            float x = Mathf.Cos(currentAngle) * orbitRadius;
            float z = Mathf.Sin(currentAngle) * orbitRadius;
            transform.position = new Vector3(centerObject.position.x + x, transform.position.y, centerObject.position.z + z);
        }
    }

    public void SetOrbitSpeed(float newSpeed)
    {
        orbitSpeed = newSpeed;
    }

    public float GetInitialOrbitSpeed()
    {
        return initialOrbitSpeed;
    }
}
