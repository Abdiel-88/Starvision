using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Transform sunTransform;
    public float distance = 100f;
    public float height = 50f;
    public float angle = 30f;

    void Start()
    {
        if (sunTransform != null)
        {
            Vector3 direction = (transform.position - sunTransform.position).normalized;
            transform.position = sunTransform.position + direction * distance;
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            transform.LookAt(sunTransform);
        }
    }
}
