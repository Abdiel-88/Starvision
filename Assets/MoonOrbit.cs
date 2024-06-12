using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    public Transform earth; // Assign Earth's transform in the Inspector
    public float orbitDistance = 1f;
    public float orbitSpeed = 10f;

    void Start()
    {
        // Set initial position based on orbit distance
        transform.position = earth.position + new Vector3(orbitDistance, 0, 0);
    }

    void Update()
    {
        // Rotate around the Earth
        transform.RotateAround(earth.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
