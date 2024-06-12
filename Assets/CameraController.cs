using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 200f; // Increased rotation speed

    void Update()
    {
        if (Input.GetMouseButton(1)) // Check if right mouse button is held down
        {
            // Movement
            float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            float upDown = 0;

            if (Input.GetKey(KeyCode.Q))
            {
                upDown = moveSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                upDown = -moveSpeed * Time.deltaTime;
            }

            transform.Translate(new Vector3(horizontal, upDown, vertical));

            // Rotation
            float rotateHorizontal = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            float rotateVertical = -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

            transform.Rotate(new Vector3(rotateVertical, rotateHorizontal, 0));
        }
    }
}
