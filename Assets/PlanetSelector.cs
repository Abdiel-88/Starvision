using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetSelector : MonoBehaviour
{
    public CameraControl cameraControl; // Reference to the CameraControl script
    public GameObject planetInfoPanel; // Reference to the Planet Info Panel

    private bool isDoubleClick = false;
    private float doubleClickTimeLimit = 0.25f;

    void Start()
    {
        if (planetInfoPanel == null)
        {
            Debug.LogError("Planet Info Panel is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("Planet Info Panel assigned correctly.");
            planetInfoPanel.SetActive(false); // Ensure the panel is hidden at the start
        }
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("Planet double-clicked: " + gameObject.name);

        if (isDoubleClick)
        {
            cameraControl.SetTarget(transform);
            if (planetInfoPanel != null)
            {
                planetInfoPanel.SetActive(true); // Show the info panel
                Debug.Log("Showing Planet Info Panel.");
            }
            isDoubleClick = false;
        }
        else
        {
            isDoubleClick = true;
            Invoke("ResetDoubleClick", doubleClickTimeLimit);
        }
    }

    void ResetDoubleClick()
    {
        isDoubleClick = false;
    }

    void OnDisable()
    {
        if (planetInfoPanel != null)
        {
            planetInfoPanel.SetActive(false); // Hide the info panel
            Debug.Log("Hiding Planet Info Panel.");
        }
    }
}
