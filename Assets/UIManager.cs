using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel; // Reference to the InfoPanel
    public TextMeshProUGUI planetNameText; // Reference to the planet name text
    public TextMeshProUGUI planetInfoText; // Reference to the planet info text
    public CameraControl cameraControl; // Reference to the CameraControl script

    private void Start()
    {
        infoPanel.SetActive(false); // Ensure the panel is hidden at the start
    }

    public void ShowInfo(string planetName, string planetInfo)
    {
        planetNameText.text = planetName;
        planetInfoText.text = planetInfo;
        infoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }

    public void OnPlanetButtonClicked(GameObject planet)
    {
        Debug.Log("Planet button clicked: " + planet.name); // Add this line
        // Directly set the camera target to the planet
        cameraControl.SetTarget(planet.transform);
        ShowInfo(planet.name, ""); // Assuming you want to show the info panel when a planet is selected
    }

    public void OnOrbitCameraButtonClicked()
    {
        Debug.Log("Orbit camera button clicked"); // Add this line
        // Reset the camera to the initial view
        cameraControl.ResetCamera();
        HideInfo();
    }
}
